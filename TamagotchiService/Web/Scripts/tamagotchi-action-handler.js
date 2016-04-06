$(document).ready(function () {

    //Actions
    $(document).on('click', '.actionbtn', function () {
        var tamagotchiValue = $(this).val();
        var tamagotchiAttributes = tamagotchiValue.split(',');
        var tamagotchiId = tamagotchiAttributes[0];
        if (isNaN(tamagotchiId))
            return;
        ExecuteAction(tamagotchiId, tamagotchiAttributes[1]);
    });

    function ExecuteAction(tamagotchiId, actionName) {
        //Ajax call to method, we don't want a postback to occur
        $.ajax({
            url: "/Home/ExecuteAction/?selectedtamagotchiid=" + tamagotchiId + "&actionname=" + actionName,
            type: "GET",
            success: function (response) {
                alert(response);
            },
            error: function () {
                console.log("Probleem met actie");
                return;
            }
        });
    }
});