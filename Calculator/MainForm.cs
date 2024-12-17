using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Windows.Forms;
using OrdinaryCalc.Lib;
using ArithmeticCalc.Lib;
using InfoFormI;

namespace Calculator
{
    public partial class CalcForm : Form
    {
        private double FirstValue;
        private string currentOperation;
        private OrdinaryCalcLib calculator;
        private ArithmeticCalcLib arifmetic_calculator;
        private Stack<double> valuesStack;
        private Stack<string> operationsStack;

        public CalcForm()
        {
            InitializeComponent();
            calculator = new OrdinaryCalcLib();
            arifmetic_calculator = new ArithmeticCalcLib();
            valuesStack = new Stack<double>();
            operationsStack = new Stack<string>();

            this.Size = new Size(400, 600);
            for (int i = 4; i < tableLayoutPanelChooseFunction.ColumnCount; i++)
            {
                tableLayoutPanelChooseFunction.ColumnStyles[i].SizeType = SizeType.Absolute;
                tableLayoutPanelChooseFunction.ColumnStyles[i].Width = 0;
            }
        }

        private void buttonNumberZero_Click(object sender, EventArgs e)
        {
            AppendDigit("0");
        }

        private void buttonNumberOne_Click(object sender, EventArgs e)
        {
            AppendDigit("1");
        }

        private void buttonNumberTwo_Click(object sender, EventArgs e)
        {
            AppendDigit("2");
        }

        private void buttonNumberThree_Click(object sender, EventArgs e)
        {
            AppendDigit("3");
        }

        private void buttonNumberFour_Click(object sender, EventArgs e)
        {
            AppendDigit("4");
        }

        private void buttonNumberFive_Click(object sender, EventArgs e)
        {
            AppendDigit("5");
        }

        private void buttonNumberSix_Click(object sender, EventArgs e)
        {
            AppendDigit("6");
        }

        private void buttonNumberSeven_Click(object sender, EventArgs e)
        {
            AppendDigit("7");
        }

        private void buttonNumberEight_Click(object sender, EventArgs e)
        {
            AppendDigit("8");
        }

        private void buttonNumberNine_Click(object sender, EventArgs e)
        {
            AppendDigit("9");
        }

        private void buttonSymbolPoint_Click(object sender, EventArgs e)
        {
            if (!textBoxShowResult.Text.Contains(","))
            {
                textBoxShowResult.Text += ",";
            }
        }

        private void buttonOperationSumma_Click(object sender, EventArgs e)
        {
            PushOperation("+");
        }

        private void buttonOperationDifference_Click(object sender, EventArgs e)
        {
            PushOperation("-");
        }

        private void buttonOperationMultiplication_Click(object sender, EventArgs e)
        {
            PushOperation("*");
        }

        private void buttonOperationQuotient_Click(object sender, EventArgs e)
        {
            PushOperation("/");
        }

        private void buttonChangeSign_Click(object sender, EventArgs e)
        {
            PushOperation("+-");
        }

        private void buttonOperationPercent_Click(object sender, EventArgs e)
        {
            PushOperation("%");
        }

        private void buttonFindSqrt_Click(object sender, EventArgs e)
        {
            PushOperation("sqrt");
        }

        private void buttonFindSquare_Click(object sender, EventArgs e)
        {
            PushOperation("square");
        }

        private void buttonFindReciprocal_Click(object sender, EventArgs e)
        {
            PushOperation("rec");
        }

        private void buttonFindLn_Click(object sender, EventArgs e)
        {
            PushOperation("ln");
        }

        private void buttonFindExp_Click(object sender, EventArgs e)
        {
            PushOperation("exp");
        }

        private void buttonFindPi_Click(object sender, EventArgs e)
        {
            double pi = arifmetic_calculator.CalcPi();
            textBoxShowResult.Text = pi.ToString();
        }

        private void buttonFindCos_Click(object sender, EventArgs e)
        {
            PushOperation("cos");
        }

        private void buttonFindSin_Click(object sender, EventArgs e)
        {
            PushOperation("sin");
        }

        private void buttonFindTan_Click(object sender, EventArgs e)
        {
            PushOperation("tan");
        }

        private void buttonFindPowerOfTen_Click(object sender, EventArgs e)
        {
            PushOperation("powoften");
        }

        private void buttonFindPowerOfNumbers_Click(object sender, EventArgs e)
        {
            PushOperation("powofn");
        }

        private void buttonFindFactorial_Click(object sender, EventArgs e)
        {
            PushOperation("fact");
        }

        private void buttonFindAbs_Click(object sender, EventArgs e)
        {
            PushOperation("abs");
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void buttonClearSymbol_Click(object sender, EventArgs e)
        {
            if (textBoxShowResult.Text.Length > 0)
            {
                textBoxShowResult.Text = textBoxShowResult.Text.Substring(0, textBoxShowResult.Text.Length - 1);
            }
        }

        private void buttonOperationResult_Click(object sender, EventArgs e)
        {
            CalculateResult();
        }

        private void AppendDigit(string digit)
        {
            if (textBoxShowResult.Text == "0" && digit != ",")
            {
                textBoxShowResult.Text = digit;
            }
            else
            {
                textBoxShowResult.Text += digit;
            }
        }

        private void PushOperation(string operation)
        {
            double currentValue = Convert.ToDouble(textBoxShowResult.Text);
            valuesStack.Push(currentValue);
            operationsStack.Push(operation);
            textBoxShowResult.Text = "0";
        }

        private void CalculateResult()
        {
            double currentValue = Convert.ToDouble(textBoxShowResult.Text);
            valuesStack.Push(currentValue);

            while (operationsStack.Count > 0)
            {
                string operation = operationsStack.Pop();
                double value2 = valuesStack.Pop();
                double value1 = valuesStack.Pop();
                double result = PerformOperation(operation, value1, value2);
                valuesStack.Push(result);
            }

            double finalResult = valuesStack.Pop();
            textBoxShowResult.Text = finalResult.ToString();
            labelShowExpression.Text = finalResult.ToString();
        }

        private double PerformOperation(string operation, double value1, double value2)
        {
            switch (operation)
            {
                case "+":
                    return calculator.CalcSumma(value1, value2);
                case "-":
                    return calculator.CalcDifference(value1, value2);
                case "*":
                    return calculator.CalcMultiplication(value1, value2);
                case "/":
                    return calculator.CalcQuotient(value1, value2);
                case "+-":
                    return -value1;
                case "%":
                    return calculator.CalcPercentage(value1);
                case "sqrt":
                    return calculator.CalcSquareRoot(value1);
                case "square":
                    return calculator.CalcSquare(value1);
                case "rec":
                    return calculator.CalcReciprocal(value1);
                case "ln":
                    return arifmetic_calculator.CalcNaturalLogarithm(value1);
                case "exp":
                    return arifmetic_calculator.CalcExponent(value1);

                case "cos":
                    return arifmetic_calculator.CalcCos(value1);
                case "sin":
                    return arifmetic_calculator.CalcSin(value1);
                case "tan":
                    return arifmetic_calculator.CalcTan(value1);
                case "powoften":
                    return arifmetic_calculator.CalcPowerOfTen(value1);
                case "powofn":
                    return arifmetic_calculator.CalcPowerOfNumber(value1, value2);
                case "fact":
                    return arifmetic_calculator.CalcFactorial(value1);
                case "abs":
                    return arifmetic_calculator.CalcAbsoluteValue(value1);
                default:
                    throw new InvalidOperationException("Неизвестная операция");
            }
        }

        private void ClearAll()
        {
            textBoxShowResult.Clear();
            labelShowExpression.Text = "";
            FirstValue = 0;
            currentOperation = string.Empty;
            valuesStack.Clear();
            operationsStack.Clear();
        }

        private void ToolStripMenuItemArithmetic_Click(object sender, EventArgs e)
        {
            this.Size = new Size(550, 600);
            int columnCount = tableLayoutPanelChooseFunction.ColumnCount;
            for (int i = 0; i < columnCount; i++)
            {
                tableLayoutPanelChooseFunction.ColumnStyles[i].SizeType = SizeType.Percent;
                tableLayoutPanelChooseFunction.ColumnStyles[i].Width = 100.0f / columnCount;
            }
        }

        private void ToolStripMenuItemOrdinary_Click(object sender, EventArgs e)
        {
            this.Size = new Size(400, 600);
            for (int i = 5; i < tableLayoutPanelChooseFunction.ColumnCount; i++)
            {
                tableLayoutPanelChooseFunction.ColumnStyles[i].SizeType = SizeType.Absolute;
                tableLayoutPanelChooseFunction.ColumnStyles[i].Width = 0;
            }
        }
        private void ToolStripMenuItemInfo_Click(object sender, EventArgs e)
        {
            InfoFormIG infoForm = new InfoFormIG();
            infoForm.Show();
        }
    }
}