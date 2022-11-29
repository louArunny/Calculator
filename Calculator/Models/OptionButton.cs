using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class OptionButton
    {
        public Option Option { get; set; }
        public string Description { get; set; } = String.Empty;

        public OptionButton()
        {

        }

        public OptionButton(Option option, string description)
        {
            Option = option;
            Description = description;
        }

    }
}
