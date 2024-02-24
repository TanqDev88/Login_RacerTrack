            document.addEventListener('DOMContentLoaded', function () {
                const calculadoraForm = document.getElementById('calculadoraForm');
                const txtCosto = document.getElementById('txtCosto');
                const txtCantidad = document.getElementById('txtCantidad');
                const btnCalcular = document.getElementById('btnCalcular');
                const txtResultado = document.getElementById('txtResultado');
                const chkSumar50000 = document.getElementById('chkSumar50000');
                const btnLimpiar = document.getElementById('btnLimpiar');

                btnCalcular.addEventListener('click', function () {
                    const costo = parseFloat(txtCosto.value);
                    const cantidad = parseInt(txtCantidad.value);
                    const opcionOperacion = document.querySelector('input[name="opcionOperacion"]:checked');

                    if (!isNaN(costo) && !isNaN(cantidad) && opcionOperacion) {
                        const operacionValue = opcionOperacion.value;

                        let resultado = costo * cantidad;

                        // Realiza la operación adicional según la opción seleccionada
                        if (operacionValue === 'opcion1') {
                            resultado += 10000;
                        } else if (operacionValue === 'opcion2') {
                            resultado += 20000; // Suma 10000
                        } else if (operacionValue === 'opcion3') {
                            resultado += 30000; // Suma 30000
                        }

                        // Suma 50000 si el checkbox está marcado
                        if (chkSumar50000.checked) {
                            resultado += 50000;
                        }

                        txtResultado.value = resultado.toFixed(2);
                    } else {
                        alert('Por favor, ingrese valores numéricos válidos, seleccione una opción de operación y marque o desmarque la opción de suma.');
                    }
                });

                btnLimpiar.addEventListener('click', function () {
                    // Limpia todos los campos del formulario
                    txtCosto.value = '';
                    txtCantidad.value = '';
                    document.querySelector('input[name="opcionOperacion"]:checked').checked = false;
                    chkSumar50000.checked = false;
                    txtResultado.value = '';
                });
            });