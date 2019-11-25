using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Validadores
{
    public abstract class Validador<T>
    {
        public delegate bool ValidadorPropiedad();
        public delegate string MensajeError();

        private IEnumerable<ValidadorPropiedad> Validaciones = new List<ValidadorPropiedad>();
        private IDictionary<ValidadorPropiedad, MensajeError> Errores = new Dictionary<ValidadorPropiedad, MensajeError>();

        public T Propiedad { get; }
        public MensajeError UltimoError { get; private set; }

        protected Validador(T propiedad)
        {
            Propiedad = propiedad;
        }

        protected abstract void DefinirValidaciones();

        protected void AgregarValidacion(ValidadorPropiedad validadorPropiedad, MensajeError mensajeError)
        {
            (Validaciones as List<ValidadorPropiedad>).Add(validadorPropiedad);

            if (mensajeError != null)
            {
                Errores[validadorPropiedad] = mensajeError;
            }
        }

        public bool Validar()
        {
            bool resultado = true;

            (Validaciones as List<ValidadorPropiedad>).ForEach(validador =>
            {
                if (!validador())
                {
                    MensajeError mensajeError = Errores[validador];

                    if (mensajeError != null)
                    {
                        UltimoError = mensajeError;
                    }

                    resultado = false;
                    return;
                }
            });

            return resultado;
        }
    }
}
