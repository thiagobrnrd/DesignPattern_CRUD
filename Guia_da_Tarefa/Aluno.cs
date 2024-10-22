using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia_da_Tarefa
{
    public class Aluno
    {
        private string nome;
        private string curso;
        private string semestre;
        private int RGM;
        public Aluno(string _nome, string _curso, int _RGM, string _semestre)
        {
            nome = _nome;
            curso = _curso;
            semestre = _semestre;
            RGM = _RGM;
        }

        public Aluno()
        {
            nome = "";
            curso = "";
            RGM = 0;
            semestre = "";
        }

        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string valor)
        {
            nome = valor;
        }

        public string GetCurso()
        {
            return curso;
        }

        public void SetCurso(string valor)
        {
            curso = valor;
        }

        public string GetSemestre()
        {
            return semestre;
        }

        public void SetSemestre(string valor)
        {
            semestre = valor;
        }

        public int GetRGM()
        {
            return RGM;
        }

        public void SetRGM(int valor)
        {
            RGM = valor;
        }
    }
}
