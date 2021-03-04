using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Calc
{
    public partial class frmMain : Form
    {
        List<Operation> listOperation = new List<Operation>();

        /* лирическое отступление
               можно было бы сделать красивую оопшную штуку для ввода текста пользователем с деревом (приоритет вычислений по скобкам, умножению/сложению, и тд)
               но по заданию это не тот случай
               повесил обработку на текстбоксы на ввод только чисел с плавающей точкой
               Shift+Insert и вставка через ContextMenuStrip тоже убрана, чтобы текст нельзя было вставить (можно было просто в _TextChanged, но это скучно и банально запретил вставку
               добавление функций для вычисления в listOperation, метод вызывается по тэгу, так что его надо реализовать в классе Calculator
               
            */
        public frmMain()
        {
            InitializeComponent();
            listOperation.Add(new Operation() { Name = "+", Tag = "Compose" });
            listOperation.Add(new Operation() { Name = "-", Tag = "Substract" });
            listOperation.Add(new Operation() { Name = "*", Tag = "Multiplicate" });
            listOperation.Add(new Operation() { Name = "/", Tag = "Division" });
            listOperation.Add(new Operation() { Name = "Sin", Tag = "Sin" });
            //а это для нереализованного метода :)
            listOperation.Add(new Operation() { Name = "NULL" , Tag = "NULL"});
            cmbOperations.DataSource = listOperation;
            cmbOperations.DisplayMember = "Name";
            cmbOperations.ValueMember = "Tag";
            foreach (Control c in this.Controls)
                c.ContextMenuStrip = new ContextMenuStrip();
        }

        private void tbFirstNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = (sender as TextBox).Text.Trim();
            e.Handled = !(Char.IsDigit(e.KeyChar) || //проверка на ввод числа
                e.KeyChar == '\b' || // проверка на ввод backspase
                //хитроумная проверка на запятую
                (e.KeyChar == ',' && !text.Contains(",") && text.Length > 0 && (((sender as TextBox).SelectionStart > 0 && (sender as TextBox).SelectionLength > 0) || ((sender as TextBox).SelectionLength == 0 && text.Replace("-","").Length > 0)))
                //проверка на установку знака "-"
                //не ставится, если у нас полное выделение текста, где есть уже "-", а жаль(
                || (e.KeyChar == '-' && !text.Contains("-") && (text.Length == 0 || ( (sender as TextBox).SelectionStart == 0 && (sender as TextBox).SelectionLength== text.Length) )  ));
        }

        private void tbFirstNumber_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.KeyCode == (Keys.Shift | Keys.Insert);
        }

        private void setEnabledControl(object sender, EventArgs e)
        {
            Type typeCalc = Type.GetType("Calc.Calculator");
            object calc = Activator.CreateInstance(typeCalc);
            MethodInfo mi = typeCalc.GetMethod(cmbOperations.SelectedValue.ToString());
            btnCalc.Enabled = mi != null && tbFirstNumber.Text.Length > 0 && ((mi.GetParameters().Length > 0 && tbSecondNumber.Text.Length > 0) || mi.GetParameters().Length == 0);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            //сразу tryParse пробуем, чтобы не было ничего плохого
            double parse = 0;
            if (tbFirstNumber.Text.Trim().Length > 0 && !double.TryParse(tbFirstNumber.Text.Trim(), out parse))
                return;
            if (tbSecondNumber.Text.Trim().Length > 0 && !double.TryParse(tbSecondNumber.Text.Trim(), out parse))
                return;

            //тут я понимаю, что ООП то и не так сильно нужно
            // возможно, при постановке другой задачи, например, с тектовым вводом + с учитыванием скобок, это было бы и нужно
            // рефлексия - создаем экземпляр типа "калькулятор"
            Type typeCalc = Type.GetType("Calc.Calculator");
            object calc = Activator.CreateInstance(typeCalc, double.Parse(tbFirstNumber.Text));
            // получаем метод по тэгу в списке
            MethodInfo mi = typeCalc.GetMethod(cmbOperations.SelectedValue.ToString());
            // и если этот метод найден
            if (mi != null)
            {
                //тут смотрим, есть ли параметры для метода
                ParameterInfo[] param = mi.GetParameters();

                object[] parametersToFunc = new object[0];
                //согласен, костыль 
                if (param.Length > 0)
                {
                    parametersToFunc = new object[param.Length];
                    parametersToFunc[0] = double.Parse(tbSecondNumber.Text);
                }
                //вызываем метод и выводим на экран
                object result = mi.Invoke(calc, parametersToFunc);
                MessageBox.Show((result == null ? "NULL": result.ToString()));

            }
        }

        private void tbFirstNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}   
