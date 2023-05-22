using ConsultarCEP.Services;
using ConsultarCEP.Services.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += ExecultarBuscaCep;

        }

        private void ExecultarBuscaCep(Object sender, EventArgs args)
        {
            
            Endereco end = ViaCepService.BuscarEnderecoPorCep(CEP_DIGITADO.Text.Trim());

            CEP_DIGITADO.Text = "";

            
            LOGRADOURO.Text = String.IsNullOrEmpty(end.logradouro)? "LOGRADOURO: Não Encontrado" : $"LOGRADOURO: {end.logradouro}";
            BAIRRO.Text = String.IsNullOrEmpty(end.bairro) ? "BAIRRO: Não Encontrado" : $"BAIRRO: {end.bairro}";
            LOCALIDADE.Text = $"LOCALIDADE: {end.localidade}";
            UF.Text = $"UF: {end.uf}";
            CEP.Text = $"CEP: {end.cep}";


        }
    }
}
