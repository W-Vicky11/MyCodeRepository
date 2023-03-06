namespace calculator2
{
    public partial class Form1 : Form
    {
        double number1 = 0;
        double number2 = 0;
        double res;
        int inputnumber;

        enum Operator { none,plus,minus,multiplication,division}
        Operator mode = Operator.none;
        bool isequal = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void labelbefore_Click(object sender, EventArgs e)
        {

        }

        private void labelout_Click(object sender, EventArgs e)
        {

        }

        private void num1_Click(object sender, EventArgs e)
        {
            inputnumber = 1;
            calculator2(inputnumber);
        }

        private void num2_Click(object sender, EventArgs e)
        {
            inputnumber = 2;
            calculator2(inputnumber);
        }

        private void num3_Click(object sender, EventArgs e)
        {
            inputnumber = 3;
            calculator2(inputnumber);
        }

        private void num4_Click(object sender, EventArgs e)
        {
            inputnumber = 4;
            calculator2(inputnumber);
        }

        private void num5_Click(object sender, EventArgs e)
        {
            inputnumber = 5;
            calculator2(inputnumber);
        }

        private void num6_Click(object sender, EventArgs e)
        {
            inputnumber = 6;
            calculator2(inputnumber);
        }

        private void num7_Click(object sender, EventArgs e)
        {
            inputnumber = 7;
            calculator2(inputnumber);
        }

        private void num8_Click(object sender, EventArgs e)
        {
            inputnumber = 8;
            calculator2(inputnumber);
        }

        private void num9_Click(object sender, EventArgs e)
        {
            inputnumber = 9;
            calculator2(inputnumber);
        }

        private void num0_Click(object sender, EventArgs e)
        {
            inputnumber = 0;
            calculator2(inputnumber);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            clearall();
        }
        public void calculator2(int an)
        {
            if(mode==Operator.none)
            {
                number1 = number1 * 10 + an;
                labelout.Text = Convert.ToString(number1);
            }
            else
            {
                number2 = number2 * 10 + an;
                labelout.Text = Convert.ToString(number2);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelout.Text = Convert.ToString(number1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mode = Operator.minus;
            switchmode();
        }

        private void plus_Click(object sender, EventArgs e)
        {
            mode = Operator.plus;
            switchmode();
        }

        private void multiplication_Click(object sender, EventArgs e)
        {
            mode = Operator.multiplication;
            switchmode();
        }

        private void division_Click(object sender, EventArgs e)
        {
            mode = Operator.division;
            switchmode();
        }

        private void equal_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case Operator.plus:
                    res = number1 + number2;
                    break;
                case Operator.minus:
                    res = number1 - number2;
                    break;
                case Operator.multiplication:
                    res = number1 * number2;
                    break;
                case Operator.division:
                    res = number1 / number2;
                    break;
            }
            number1 = 0;
            number2 = 0;
            isequal = true;
            labelbefore.Text = "";
            labelmode.Text = "";
            labelout.Text = Convert.ToString(res);
        }
        public void clearall()
        {
            number1 = 0;
            number2 = 0;
            labelout.Text = Convert.ToString(number1);
            labelbefore.Text = "";
            labelmode.Text = "";
            isequal = false;
            mode = Operator.none;
        }
        public void switchmode()
        {
            switch(mode)
            {
                case Operator.plus:
                    labelmode.Text = "+";
                    break;
                case Operator.minus:
                    labelmode.Text = "-";
                    break;
                case Operator.multiplication:
                    labelmode.Text = "*";
                    break;
                case Operator.division:
                    labelmode.Text = "/";
                    break;
            }
            if(isequal==true)
            {
                number1 = res;

            }
            labelbefore.Text = Convert.ToString(number1);
            labelout.Text = Convert.ToString(number2);
        }
    }
}