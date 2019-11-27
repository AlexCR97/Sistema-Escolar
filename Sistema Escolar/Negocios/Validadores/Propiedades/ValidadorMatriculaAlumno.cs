using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Validadores.Propiedades
{
    public class ValidadorMatriculaAlumno : Validador<string>
    {
        public ValidadorMatriculaAlumno(string propiedad) : base(propiedad) { }

        protected override void DefinirValidaciones()
        {
            AgregarValidacion(() =>
            {
                try
                {
                    /**
                     * 1601F0225
                     */

                    // 1601
                    string primeraParte = Propiedad.Substring(0, 4);
                    Int32.Parse(primeraParte);

                    // 0225
                    string segundaParte = Propiedad.Substring(5, 4);
                    Int32.Parse(segundaParte);

                    return true;
                }
                catch
                {
                    return false;
                }
            }, () => "La matricula debe de tener el siguiente formato: 1601F0225 (AANNFNNNN)");
        }
    }
}
