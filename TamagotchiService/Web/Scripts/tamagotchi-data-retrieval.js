$(document).ready(function () {

    var lastData = null;

    if (Notification.permission !== "granted") {
        Notification.requestPermission();
    }

    //Initial load
    ReloadTamagotchies();
    setInterval(ReloadTamagotchies, 60000);

    function ReloadTamagotchies() {
        $.ajax({
            dataType: "json",
            url: "Home/ReloadTamagotchies",
            type: "get",
            success: function (result) {
                if (result == null)
                    return;
                if (lastData === null || JSON.stringify(lastData) != JSON.stringify(result)) {
                    ShowBrowserNotification("Tamagotchies vervest", "Uw tamagotchies zijn up-to-date!", "http://tamagotchiweb20160109052336.azurewebsites.net/", "Img/Loading.gif");
                }
                lastData = result;
                RepopulateTable(result);
            },
            error: function () {
                console.log("Probleem met ophalen data");
                return;
            }
        });
    }

    function RepopulateTable(tamagotchies) {
        //Show loading gif
        $("#loadinggif").fadeIn().delay(2500).fadeOut();
        //Clear table
        $("#tamagotchitable").empty();
        //Get table
        var tamTable = $("#tamagotchitable");
        //Table header
        var tableheader = "<thead><tr><th class='th-w-20'>Naam</th><th class='th-w-20'>Avatar</th><th class='th-w-20'>Status</th><th class='th-w-10'>Honger</th><th class='th-w-10'>Slaap</th><th class='th-w-10'>Verveling</th><th class='th-w-10'>Gezondheid</th><th class='th-w-10'>Opties</th></tr></thead>";
        //Add table header
        tamTable.append(tableheader);
        //Table body
        var tablebody = "<tbody>";
        for (i = 0; i < tamagotchies.length; i++) {
            //Table datarows
            var datarow = "";
            datarow += "<tr><td>" + tamagotchies[i].TamagotchiName + "</td>";
            var url = GetImageUrl(tamagotchies[i].State);
            datarow += "<td><img src='" + url + "' style='width:20px; height:20px;'/></td>";
            datarow += "<td>" + tamagotchies[i].State + "</td><td>" + tamagotchies[i].Hunger + "</td><td>" + tamagotchies[i].Sleep + "</td><td>" + tamagotchies[i].Boredom + "</td><td>" + tamagotchies[i].Health + "</td>";
            var detailsurl = "/Home/TamagotchiDetails?selectedtamagotchiid=" + tamagotchies[i].TamagotchiId;
            datarow += "<td><a href='" + detailsurl + "' class='btn btn-xs btn-primary'>Bekijk</a></td></tr>";
            tablebody += datarow;
            //Table actionrows
            var actionrow = "";
            actionrow += "<tr class='tr-option'><td>";
            var isdisabled = "";
            //if (tamagotchies[i].IsDead || tamagotchies[i].IsLocked) {
            //    isdisabled = "disabled";
            //}
            actionrow += "<button type='submit' class='btn btn-xs btn-default actionbtn' value='" + tamagotchies[i].TamagotchiId + ",EAT' " + isdisabled + ">Eet</button>";
            actionrow += "<button type='submit' class='btn btn-xs btn-default actionbtn' value='" + tamagotchies[i].TamagotchiId + ",SLEEP' " + isdisabled + ">Slaap</button>";
            actionrow += "<button type='submit' class='btn btn-xs btn-default actionbtn' value='" + tamagotchies[i].TamagotchiId + ",PLAY' " + isdisabled + ">Speel</button>";
            actionrow += "<button type='submit' class='btn btn-xs btn-default actionbtn' value='" + tamagotchies[i].TamagotchiId + ",WORKOUT' " + isdisabled + ">Sport</button>";
            actionrow += "<button type='submit' class='btn btn-xs btn-default actionbtn' value='" + tamagotchies[i].TamagotchiId + ",HUG' " + isdisabled + ">Knuffel</button>";
            actionrow += "</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>";
            tablebody += actionrow;
        }
        tablebody += "</tbody>";
        //Add table body
        tamTable.append(tablebody);
    }

    function GetImageUrl(State) {
        if (State == "Hongerig") { return "Img/Hunger.png"; }
        if (State == "Ongezond") { return "Img/Health.png"; }
        if (State == "Verveeld") { return "Img/Boredom.png"; }
        if (State == "Slaperig") { return "Img/Sleep.png"; }
        if (State == "Dood") { return "Img/Dead.png"; }
        if (State == "Normaal") { return "Img/Normaal.png";}
        return "Img/Normaal.png";
    }

    //Show notification
    function ShowBrowserNotification(notetitle, notebody, noteurl, noteicon) {
        if (!Notification) {
            console.log('Desktop notificaties zijn niet beschikbaar voor uw pc.');
            return;
        }
        if (Notification.permission !== "granted")
            Notification.requestPermission();
        else {
            var notification = new Notification(notetitle, {
                icon: noteicon,
                body: notebody,
            });
            notification.onclick = function () {
                window.open(noteurl);
            };
        }
    }
});