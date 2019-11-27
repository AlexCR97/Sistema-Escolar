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
            DefinirValidaciones();
        }

        protected abstract void DefinirValidaciones();

        protected void AgregarValidacion(ValidadorPropiedad validadorPropiedad, MensajeError mensajeError)
        {
            Console.WriteLine("VALIDADOR AGREGADO");

            (Validaciones as List<ValidadorPropiedad>).Add(validadorPropiedad);

            if (mensajeError != null)
            {
                Errores[validadorPropiedad] = mensajeError;
            }
        }

        public bool Validar()
        {
            foreach (ValidadorPropiedad validador in Validaciones)
            {
                if (!validador.Invoke())
                {
                    MensajeError mensajeError = Errores[validador];

                    if (mensajeError != null)
                    {
                        UltimoError = mensajeError;
                    }

                    return false;
                }
            }
            return true;
        }
    }
}
