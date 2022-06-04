using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PELICULAS_WW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridcar();
        }

        private void gridcar()
        {
            PeliculasEntitiesConexion pelicontex = new PeliculasEntitiesConexion();
            GridWizzardWorl.DataSource = pelicontex.tb_peliculas.ToList();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAñadir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.textBoxIdpeliculas.Text);
            string estre=textBoxEstreno.Text;
            string titu=textBoxTitulo.Text;
            string direc=textBoxDirector.Text;
            int taq=int.Parse(this.textBoxTaquilla.Text);
            string gen=textBoxGenero.Text;
            string prota=textBoxProtagonistas.Text;
            string compa=textBoxCompañia.Text;

            using (PeliculasEntitiesConexion pelicontext= new PeliculasEntitiesConexion())
            {
                tb_peliculas pww = new tb_peliculas
                {
                    IdPelicula = id,
                    Estreno = estre,
                    Titulo = titu,
                    Director = direc,
                    Taquilla = taq,
                    Genero = gen,
                    Protagonistas = prota,
                    Compañia = compa,
                };
                pelicontext.tb_peliculas.Add(pww);
                pelicontext.SaveChanges();
                gridcar();
            }
        }

        private void obtedato()
        {
            this.textBoxIdpeliculas.Text = GridWizzardWorl.SelectedRows[0].Cells[0].Value.ToString();
            this.textBoxEstreno.Text= GridWizzardWorl.SelectedRows[0].Cells[1].Value.ToString();
            this.textBoxTitulo.Text= GridWizzardWorl.SelectedRows[0].Cells[2].Value.ToString();
            this.textBoxDirector.Text= GridWizzardWorl.SelectedRows[0].Cells[3].Value.ToString();
            this.textBoxTaquilla.Text= GridWizzardWorl.SelectedRows[0].Cells[4].Value.ToString();
            this.textBoxGenero.Text= GridWizzardWorl.SelectedRows[0].Cells[5].Value.ToString();
            this.textBoxProtagonistas.Text= GridWizzardWorl.SelectedRows[0].Cells[6].Value.ToString();
            this.textBoxCompañia.Text= GridWizzardWorl.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void GridWizzardWorl_Click(object sender, EventArgs e)
        {
            obtedato();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            int idp = Convert.ToInt16(this.textBoxIdpeliculas.Text);
            string estre = textBoxEstreno.Text;
            string titu = textBoxTitulo.Text;
            string direc = textBoxDirector.Text;
            int taq = int.Parse(this.textBoxTaquilla.Text);
            string gen = textBoxGenero.Text;
            string prota = textBoxProtagonistas.Text;
            string compa = textBoxCompañia.Text;
            using (PeliculasEntitiesConexion pelicontex= new PeliculasEntitiesConexion())
            {
                tb_peliculas pww = pelicontex.tb_peliculas.FirstOrDefault(consul => consul.IdPelicula == idp);
                pww.Estreno = estre;
                pww.Titulo = titu;
                pww.Director = direc;
                pww.Taquilla = taq;
                pww.Genero=gen;
                pww.Protagonistas=prota;
                pww.Compañia = compa;
                pelicontex.SaveChanges();
                gridcar();
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int idp = Convert.ToInt16(this.textBoxIdpeliculas.Text);
            using (PeliculasEntitiesConexion pelicontex = new PeliculasEntitiesConexion())
            {
                tb_peliculas pww = pelicontex.tb_peliculas.FirstOrDefault(consul => consul.IdPelicula == idp);
                pelicontex.tb_peliculas.Remove(pww);
                pelicontex.SaveChanges();
                gridcar();
            }
        }

        private void GridWizzardWorl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxEstreno_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
