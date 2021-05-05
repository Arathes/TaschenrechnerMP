using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class Controller
    {
        
        private Operations? operation = null;
        private float? operand1 = null;
        private float? operandC1 = null;
        private float? operand2 = null;
        private float? operandC2 = null;
        private Boolean comma = false;

        public float? OperandC1 { get => operandC1; set => operandC1 = value; }
        public float? OperandC2 { get => operandC2; set => operandC2 = value; }

        public void setComma(Boolean input)
        {
            this.comma = input;
        }

        public Boolean getComma()
        {
            return this.comma;
        }
        public float? getOperand1()
        {
            return operand1;
        }

        public float? getOperand2()
        {
            return operand2;
        }
        public void setOperand2(float? input)
        {
            this.operand2 = input;
        }

        public Operations? getOperation()
        {
           return operation;
        }
        public void setOperation(Operations? input) {
            operation = input;
            comma = false;
        }

        public float? findLeastImportantNumber(float? operand)
        {
            //int PosofLowestWholeNumber =  operand.ToString().IndexOf('.')  -  1;
            
            float leastImportant = float.Parse(operand.ToString().ElementAt(operand.ToString().Length-1)+"");
            return leastImportant;
        }

        public float? findLeastImportantNumberComma(float? operand)
        {
            float leastImportant = float.Parse(operand.ToString().ElementAt(operand.ToString().Length-1)+"");
            leastImportant = leastImportant * (float)Math.Pow(10.0, -(operand.ToString().Length - 2));
            return leastImportant;
        }

        public void deleteLastInput()
        {

            if (operation == null)
            {
                //PreComma OP1
                if (comma == false)
                {
                    if (operand1 == null)
                    {
                        //Do Nothing
                    }
                    else
                    {
                        if (operand1.ToString().Length <= 1)
                        {
                            operand1 = null;
                        }
                        else
                        {
                            operand1 = (operand1 - findLeastImportantNumber(operand1)) / 10;
                        }
                    }
                }
                //PostComma OP1
                else
                {
                    if (OperandC1 == null)
                    {
                        this.comma = false;
                    }
                    else
                    {
                        operand1 -= operandC1;
                        if (operandC1.ToString().Length <= 3)
                        {
                            
                            operandC1 = null;
                        }
                        else
                        {
                      
                            operandC1 = (operandC1 - findLeastImportantNumberComma(operandC1));
                            operand1 = operand1 + operandC1;
                        }
                    }
                }
            }
            //Operation and OP 1 selected
            else if (operation != null && operand2 == null)
            {
                this.operation = null;
            } else
            {
                //PreComma OP2
                if (comma == false)
                {
                    if (operand2 == null)
                    {
                        //Do Nothing
                    }
                    else
                    {

                        if (operand2.ToString().Length <= 1)
                        {
                            operand2 = null;
                        }
                        else
                        {
                            operand2 = (operand2 - findLeastImportantNumber(operand2)) / 10;
                        }
                    }

                }
                //PostComma OP2
                else
                {
                    if (OperandC2 == null)
                    {
                        this.comma = false;
                    }
                    else
                    {
                        operand2 -= operandC2;
                        if (operandC2.ToString().Length <= 3)
                        {
                            operandC2 = null;
                        }
                        else
                        {
                            operandC2 = (operandC2 - findLeastImportantNumberComma(operandC2));
                            operand2 = operand2 + operandC2;
                        }
                    }
                    
                }
            }
        }

        public void resetAll()
        {
            this.operand1 = null;
            this.operand2 = null;
            this.OperandC1 = null;
            this.OperandC2 = null;
            this.operation = null;
            this.comma = false;
        }

        //no Operation means first input
        public void expandOperand(float toAdd) {

            if (operation == null)
            {
                //PreComma OP1
                if (comma == false)
                {
                    if (operand1 == null)
                    {
                        operand1 = toAdd;
                    }
                    else
                    {
                        operand1 = doHornerBaby(operand1, toAdd);
                    }
                }
                //PostComma OP1
                else
                {
                    if (OperandC1 == null)
                    {
                        OperandC1 = toAdd / 10;
                    }
                    else
                    {
                        operand1 -= operandC1;
                        operandC1 = doHornerComma(OperandC1, toAdd);
                    }
                    operand1 = operand1 + operandC1;
                }
            }
            else
            {
                //PreComma OP2
                if (comma == false)
                {
                    if (operand2 == null)
                    {
                        operand2 = toAdd;
                    }
                    else
                    {
                        operand2 = doHornerBaby(operand2, toAdd);
                    }

                } 
                //PostComma OP2
                else
                {
                    if (OperandC2 == null)
                    {
                        OperandC2 = toAdd / 10;
                    }
                    else
                    {
                        operand2 -= operandC2;
                        operandC2 = doHornerComma(OperandC2, toAdd);
                    }
                    operand2 = operand2 + operandC2;
                }
            }
        }

        public float? doHornerBaby(float? operand, float input) {

            if (input == 0)
            {
                return (operand * 10);
            }
            return (operand*10) + input;
        }

        public float? doHornerComma(float? operand, float input)
        {
            if (input == 0)
            {
                return (operand * 10);
            }
            double operandL = operand.ToString().Length;
            input = input * (float) Math.Pow(10.0, -(operandL-1));

            return operand + input;
        }

        public void writeHistory()
        {

        }

        public void changeSign()
        {
            if (operation == null)
            {
                //PreComma OP1
                if (operand1 == null)
                {
                    //Nothing to do
                }
                else
                {
                    operand1 = operand1 * -1;
                }
            } else
            {
                if (operand2 == null)
                {
                    //Nothing to do
                }
                else
                {
                    operand2 = operand2 * -1;
                }
            }

        }

        public float? executeCalculus() {
            switch (operation) { 
                case Operations.Add:
                    operand1 = operand1 + operand2;
                    return operand1;
                case Operations.Subtract:
                    operand1 = operand1 - operand2;
                    return operand1;
                case Operations.Multiply:
                    operand1 = operand1 * operand2;
                    return operand1;
                case Operations.Divide:
                    operand1 = operand1 / operand2;
                    return operand1;
                default:
                    return 0;
            }
        }

    }
}
