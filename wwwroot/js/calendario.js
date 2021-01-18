
function soloLetras(e) 
                {                                        
                        key = e.keyCode || e.which;
                        tecla = String.fromCharCode(key).toLowerCase();
                        
                        letras = " áéíóúabcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTVWXYZÁÉÍÓÚÜ";
                        especiales = " ";
                        tecla_especial = false
                        for (var i in especiales) 
                        {
                            if (key == especiales[i] ) 
                            {
                                tecla_especial = true;                                   
                                break;                                
                            }
                            
                        }
                         if (letras.indexOf(tecla) == -1 && !tecla_especial) {return false;}                        
                };

function soloCorreo(e) 
                {                                        
                        key = e.keyCode || e.which;
                        tecla = String.fromCharCode(key).toLowerCase();
                        
                        letras = " áéíóúabcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTVWXYZÁÉÍÓÚÜ@_-.";
                        especiales = " ";
                        tecla_especial = false
                        for (var i in especiales) 
                        {
                            if (key == especiales[i] ) 
                            {
                                tecla_especial = true;                                   
                                break;                                
                            }
                            
                        }
                         if (letras.indexOf(tecla) == -1 && !tecla_especial) {return false;}                        
                };                


 document.getElementById("Nombre").addEventListener("keydown", teclear);        
 document.getElementById("Correo").addEventListener("keydown", teclear);        
 
 var flag = false;
            var teclaAnterior = "";

            function teclear(event) {
                teclaAnterior = teclaAnterior + " " + event.keyCode;
                var arregloTA = teclaAnterior.split(" ");
                if (event.keyCode == 32 && arregloTA[arregloTA.length - 2] == 32) {
                    event.preventDefault();
                }
            }


 function comprobarCorreo(correo){
           var correo = document.getElementById('Correo').value;
           //Una implementación del Estandard Official: RFC 5322:
        var patron = new RegExp("^(([^<>()\[\]\\.,;:\s@]+(\.[^<>()\[\]\\.,;:\s@]+)*)|(.+))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$");
           var comprobacion = patron.test(correo);
           if (comprobacion != false) 
           {
                document.getElementById('validacion2').innerHTML = ' .Incorrecto'; 
                document.getElementById('validacion2').style.color = 'green';
           }
           else
           {
               document.getElementById('validacion2').innerHTML = ' Correcto';
               document.getElementById('validacion2').style.color = 'red';
           }; 
           return comprobacion;
       };