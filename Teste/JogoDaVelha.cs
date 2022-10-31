﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JogoDaVelha
{
    class JogoDaVelha
    {
        private bool fimDeJogo { get; set; }
        private char[] posicoes { get; set; }
        private char vez;
        private int quantidadePreenchida;
        public JogoDaVelha()
        {
            fimDeJogo = false;
            posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vez = 'X';
            quantidadePreenchida = 0;
        }

        public void Iniciar()
        {
            while (!fimDeJogo)
            {
                RenderizarTabela();
                LerEscolhaDeUsuario();
                RenderizarTabela();
                VerificarFimDeJogo();
                MudarVez();
            }
        }

        private void MudarVez()
        {
            vez = vez == 'X' ? 'O' : 'X';
        }

        private void VerificarFimDeJogo()
        {
            if (quantidadePreenchida < 5)
            {
                return;
            }
            if (ExisteVitoriaDiagonal() || ExisteVitoriaVertical() || ExisteVitoriaHorizontal())
            {
                fimDeJogo = true;
                Console.WriteLine($"Fim de jogo!!! Vitória de {vez}");
                return;
            }
            if (quantidadePreenchida is 9)
            {
                fimDeJogo = true;
                Console.WriteLine("Fim de jogo!!! EMPATE");
            }
        }
        private bool ExisteVitoriaHorizontal()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool vitoriaLinha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool vitoriaLinha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }
        private bool ExisteVitoriaVertical()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool vitoriaLinha2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool vitoriaLinha3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }
        private bool ExisteVitoriaDiagonal()
        {
            bool vitoriaLinha1 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];
            bool vitoriaLinha2 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2;
        }
        private void LerEscolhaDeUsuario()
        {
            Console.WriteLine($"Agora é a vez de {vez}, entre uma posição de 1 a 9 que esteja disponível na tabela");
            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);
            while (!conversao || !ValidarEscolhaUsuario(posicaoEscolhida))
            {
                Console.WriteLine("O campo escolhido é invalido, por favor digite um número entre 1 e 9 que esteja disponível na tabela");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }
            PreencherEscolha(posicaoEscolhida);
        }

        private void PreencherEscolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;
            posicoes[indice] = vez;
            quantidadePreenchida++;
        }

        private bool ValidarEscolhaUsuario(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;
            return posicoes[indice] != 'O' && posicoes[indice] != 'X';
        }

        private void RenderizarTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }
        private string ObterTabela()
        {
            return $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__\n" +
                   $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__\n" +
                   $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  \n\n";
        }
    }
}
