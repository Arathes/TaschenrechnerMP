using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taschenrechner
{
    public partial class Form1 : Form
    {
        Controller c = new Controller();  
        public Form1()
        {
            InitializeComponent();
            
        }
        

        public void updateResultBox()
        {
            String opS = null;
            switch (c.getOperation())
            {
                case Operations.Add:
                    opS = "+";
                    break;
                case Operations.Subtract:
                    opS = "-";
                    break;
                case Operations.Multiply:
                    opS = "*";
                    break;
                case Operations.Divide:
                    opS = "/";
                    break;
            }

            if (c.getOperand1().Equals(null))
            {
                resultBox.Text = "";
            }
            if (!c.getOperand1().Equals(null))
            {
                resultBox.Text = c.getOperand1().ToString();

            }
            if (!c.getOperation().Equals(null))
            {
                resultBox.Text = resultBox.Text + " " + opS;
            } 
            if (!c.getOperand2().Equals(null))
            {
                resultBox.Text = resultBox.Text + " " + c.getOperand2().ToString();
          
            }
           
        }
        

        private void nB1_Click(object sender, EventArgs e)
        {
            c.expandOperand(1f);
            updateResultBox();
        }

        private void nB2_Click(object sender, EventArgs e)
        {
            c.expandOperand(2f);
            updateResultBox();
        }

        private void nB3_Click(object sender, EventArgs e)
        {
            c.expandOperand(3f);
            updateResultBox();
        }

        private void nB4_Click(object sender, EventArgs e)
        {
            c.expandOperand(4f);
            updateResultBox();
        }

        private void nB5_Click(object sender, EventArgs e)
        {
            c.expandOperand(5f);
            updateResultBox();
        }

        private void nB6_Click(object sender, EventArgs e)
        {
            c.expandOperand(6f);
            updateResultBox();
        }

        private void nB7_Click(object sender, EventArgs e)
        {
            c.expandOperand(7f);
            updateResultBox();
        }

        private void nB8_Click(object sender, EventArgs e)
        {
            c.expandOperand(8f);
            updateResultBox();
        }

        private void nB9_Click(object sender, EventArgs e)
        {
            c.expandOperand(9f);
            updateResultBox();
        }

        private void nB0_Click(object sender, EventArgs e)
        {
            c.expandOperand(0f);
            updateResultBox();
        }

        private void signB_Click(object sender, EventArgs e)
        {
            c.changeSign();
            updateResultBox();
        }
        
        private void additionB_Click(object sender, EventArgs e)
        {
            if (c.getOperation().Equals(null))
            {
                c.setOperation(Operations.Add);
                updateResultBox();
            }
            else if (!c.getOperation().Equals(null) && !c.getOperand2().Equals(null))
            {
                equalsButton_Click();
                c.setOperation(Operations.Add);
            }
        }
       
        private void divideB_Click(object sender, EventArgs e)
        {
            if (c.getOperation().Equals(null))
            {
                c.setOperation(Operations.Divide);
                updateResultBox();
            }
            else if (!c.getOperation().Equals(null) && !c.getOperand2().Equals(null))
            {
                equalsButton_Click();
                c.setOperation(Operations.Divide);
            }
        }
       
        private void multiplyB_Click(object sender, EventArgs e)
        {
            if (c.getOperation().Equals(null))
            {
                c.setOperation(Operations.Multiply);
                updateResultBox();
            }
            else if (!c.getOperation().Equals(null) && !c.getOperand2().Equals(null))
            {
                equalsButton_Click();
                c.setOperation(Operations.Multiply);
            }
        }
        
        private void substractB_Click(object sender, EventArgs e)
        {
            if (c.getOperation().Equals(null))
            {
                c.setOperation(Operations.Subtract);
                updateResultBox();
            } else if (!c.getOperation().Equals(null) && !c.getOperand2().Equals(null))
            {
                equalsButton_Click();
                c.setOperation(Operations.Subtract);
            }

        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            operationBox.Text = c.getOperand1().ToString() + " " + c.getOperation().ToString() + " " + c.getOperand2().ToString();
            resultBox.Text = c.executeCalculus().ToString();
            c.setOperand2(null);

        }

        private void equalsButton_Click()
        {
            operationBox.Text = c.getOperand1().ToString() + " " + c.getOperation().ToString() + " " + c.getOperand2().ToString();
            resultBox.Text = c.executeCalculus().ToString();
            c.setOperand2(null);

        }

        private void resultBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void resetB_Click(object sender, EventArgs e)
        {
            c.resetAll();
            resultBox.Text = null;
            operationBox.Text = null;
        }

        private void returnB_Click(object sender, EventArgs e)
        {
            c.deleteLastInput();
            updateResultBox();
        }

        private void commaB_Click(object sender, EventArgs e)
        {
            c.setComma(true);
            updateResultBox();
        }

        private void historyView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
