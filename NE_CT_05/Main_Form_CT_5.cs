using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NE_CT_05
{
  public partial class Main_Form_CT_5 : Form
  {
    public static double T1, T2, T3, T4, a, b, xc, yc, eps;

    public static int k1, k2, k3, k4, m, k = -1;
    public static string Result = "", title;
    List<Form_MJacoby> List_of_Tasks;

    public Main_Form_CT_5()
    {
      InitializeComponent(); List_of_Tasks = new List<Form_MJacoby>();
      cBox_eps.SelectedIndex = 1;
    }

    private void btn_Calc_Click(object sender, EventArgs e)
    {
      a = (double)UpDown_a.Value; xc = (double)UpDown_xc.Value;
      b = (double)UpDown_b.Value; yc = (double)UpDown_yc.Value;
      if ((xc > a) || (yc > b)) return;
      T1 = (double)UpDown_T1.Value; k1 = (int)UpDown_k1.Value;
      T2 = (double)UpDown_T2.Value; k2 = (int)UpDown_k2.Value;
      T3 = (double)UpDown_T3.Value; k3 = (int)UpDown_k3.Value;
      T4 = (double)UpDown_T4.Value; k4 = (int)UpDown_k4.Value;
      m = (int)UpDown_m.Value; title = tBox_title.Text;
      eps = Convert.ToDouble(cBox_eps.SelectedItem);
      k++; title += $"_{k}";
      List_of_Tasks.Add(new Form_MJacoby());
      List_of_Tasks[k].StartPosition = FormStartPosition.Manual;
      List_of_Tasks[k].Location = new Point(Location.X + 50 + k * 30, Location.Y + 275 + k * 30);
      List_of_Tasks[k].Show();
      List_of_Tasks[k].StartTask();
    }

    private void Main_Form_CT_5_FormClosing(object sender, FormClosingEventArgs e)
    {
      foreach (Form_MJacoby form_task in List_of_Tasks)
      {
        if (form_task.task == null) { form_task.Dispose(); continue; }
        if (form_task.task.IsAlive) form_task.task.Abort();
        form_task.Dispose();
      }
    }

    private void btn_Result_Click(object sender, EventArgs e)
    {
      if (k == -1) tBox_Result.Text = "Обчислень ще не було !";
      else tBox_Result.Text = Result;
    }

    private void pictureBox_About_Click(object sender, EventArgs e)
    {
      MessageBox.Show(
    "Програмно-Методична розробка Кафедри\r\n"
  + " Механіки, Автоматизації та Інформаційних Технологій\r\n"
  + "Одеського Національного Університету\r\n  імені І.І.Мечникова\r\n\r\n"
  + "Реліз: <квітень> 2024 р.", "  Інформація",
    MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

  }
}
