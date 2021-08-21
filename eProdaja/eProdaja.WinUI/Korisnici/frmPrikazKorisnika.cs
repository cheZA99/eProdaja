﻿using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdaja.WinUI.Korisnici
{
    public partial class frmPrikazKorisnika : Form
    {
        APIService _serviceKorisnici = new APIService("Korisnici");//instanca klase APIService
        public frmPrikazKorisnika()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)//takodjer asynca/awaita je obavezan
        {
            KorisniciSearchRequest request = new KorisniciSearchRequest()
            {
                Ime = txtIme.Text
            };
            dgvKorisnici.DataSource = await _serviceKorisnici.Get<List<Model.Korisnici>>(request);
        }

        private async void frmPrikazKorisnika_Load(object sender, EventArgs e)
        {
            dgvKorisnici.DataSource = await _serviceKorisnici.Get<List<Model.Korisnici>>(null);
        }
    }
}
