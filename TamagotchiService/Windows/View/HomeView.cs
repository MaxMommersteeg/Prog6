using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows.View {
    public class HomeView : ViewBase {

        public void Push(string message) {
            ResetForeGroundColor();
            Console.WriteLine(message);
        }

        public string Pull() {
            return Console.ReadLine();
        }
    }
}
