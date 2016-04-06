using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows.View {
    public abstract class ViewBase {
        protected ConsoleColor ForeGroundColor;

        public ViewBase() {
            ForeGroundColor = ConsoleColor.White;
        }

        public void Clear() {
            Console.Clear();
        }

        protected void SetForeGroundColor(ConsoleColor color) {
            ForeGroundColor = color;
        }

        protected void ResetForeGroundColor() {
            ForeGroundColor = ConsoleColor.White;
        }
    }
}
