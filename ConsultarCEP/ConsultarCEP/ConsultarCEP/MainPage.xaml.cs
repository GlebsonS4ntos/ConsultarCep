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

            if (CepIsValid(CEP_DIGITADO.Text.Trim()))
            {
                Endereco end = ViaCepService.BuscarEnderecoPorCep(CEP_DIGITADO.Text.Trim());

                CEP_DIGITADO.Text = "";

                LOGRADOURO.Text = String.IsNullOrEmpty(end.logradouro) ? "LOGRADOURO: Não Encontrado" : $"LOGRADOURO: {end.logradouro}";
                BAIRRO.Text = String.IsNullOrEmpty(end.bairro) ? "BAIRRO: Não Encontrado" : $"BAIRRO: {end.bairro}";
                LOCALIDADE.Text = $"LOCALIDADE: {end.localidade}";
                UF.Text = $"UF: {end.uf}";
                CEP.Text = $"CEP: {end.cep}";
            }
        }

        private bool CepIsValid(string cep)
        {
            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "Verifique o Cep digitado, ele precisa ter 8 caracteres !!", "Ok");
                return false;
            }
            int resultadoCep;
            if(!int.TryParse(cep,out resultadoCep))
            {
                DisplayAlert("Erro", "Verifique o Cep digitado, ele deve conter apenas Números !!", "Ok");
                return false;
            }

            return true;
        }
    }
}
