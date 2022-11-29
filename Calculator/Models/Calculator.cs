using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class Calculator
    {
        public List<OptionButton> EnteredOptions { get; set; } = new();
        public double currentNumber { get; set; }

        public Calculator() 
        { 
            resetComplete();
        }

        public void AddToCalculation(double number)
        {
            if (EnteredOptions.Count == 1 && EnteredOptions[0].Description == "0")
                EnteredOptions.Clear();
            EnteredOptions.Add(new OptionButton(Option.NUMBER, number.ToString()));
        }

        public void AddOperand(string operand)
        {
            if (EnteredOptions.Count == 0)
                return;

            if (operand == "+/-")
            {
                if (EnteredOptions[EnteredOptions.Count - 1].Option == Option.NUMBER)
                    negateOperator(chunkUp());
            }
            else
            {

                if (EnteredOptions[EnteredOptions.Count - 1].Option != Option.NUMBER)
                    EnteredOptions.RemoveAt(EnteredOptions.Count - 1);
                EnteredOptions.Add(new OptionButton(Option.OPERATOR, operand));
            }
        }

        public int chunkUp()
        {
            List<string> summands = new();
            summands.Add("");
            int indexLastOperator = -1;
            for (int i = 0; i < EnteredOptions.Count; i++)
            {
                if (EnteredOptions[i].Option == Option.NUMBER)
                {
                    summands[summands.Count - 1] += EnteredOptions[i].Description;

                }
                else
                {
                    indexLastOperator = i;
                    summands.Add("");
                }

            }

            currentNumber = double.Parse(summands[summands.Count - 1]);

            return indexLastOperator;
        }

        public void negateOperator(int index)
        {
            currentNumber = -currentNumber;


            //remove all from Buttons
            if (index == -1)
            {
                EnteredOptions.Clear();
            }
            else
            {
                index++;
                List<OptionButton> buttons = new();


                for (int i = 0; i < index; i++)
                {
                    buttons.Add(EnteredOptions[i]);
                }

                EnteredOptions = new List<OptionButton>(buttons);

            }

            fillList(currentNumber.ToString());
        }

        public void fillList(String currentNumber)
        {
            foreach (char c in currentNumber)
            {
                EnteredOptions.Add(new OptionButton(Option.NUMBER, c.ToString()));
            }
        }

        public string getStringCalculation()
        {
            string content = "";
            foreach (OptionButton button in EnteredOptions)
            {
                content += button.Description;
            }

            return content;
        }

        public string getCalculationBrackets()
        {
            string content = "";
            bool closeBrackets = false;
            foreach (OptionButton button in EnteredOptions)
            {
                if (closeBrackets && button.Option != Option.NUMBER)
                {
                    content += ")";
                    closeBrackets = false;
                }

                if (button.Option == Option.NUMBER && button.Description == "-")
                {
                    content += "(";
                    closeBrackets = true;

                }
                content += button.Description;

            }
            if (closeBrackets)
                content += ")";

            return content;
        }

        public void deleteLast()
        {
            EnteredOptions.RemoveAt(EnteredOptions.Count - 1);
        }

        public void resetComplete()
        {
            EnteredOptions.Clear();
            EnteredOptions.Add(new OptionButton(Option.NUMBER, "0"));
        }



    }
}
