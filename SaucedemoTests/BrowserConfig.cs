using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaucedemoTests
{
    public class BrowserConfig
    {
        public required string Browser { get; set; }
        public bool Headless { get; set; }
        public required WindowSize WindowSize { get; set; }
        public int ImplicitWaitSeconds { get; set; }
    }

    public class WindowSize
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
