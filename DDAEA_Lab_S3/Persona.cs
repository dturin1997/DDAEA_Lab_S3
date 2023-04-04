using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDAEA_Lab_S3
{
    public partial class Persona : Form
    {
        SqlConnection conn;
        public Persona()
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void Persona_Load(object sender, EventArgs e)
        {

        }
        private void btnPersona_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona(conn);
            persona.Show();
        }
    }
}
