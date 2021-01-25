document.getElementById("ContraseniaS").addEventListener("keydown", teclear);
$(document).on("keydown keyup", "#TiempoS", function(event) { 
    if(event.which==38 || event.which==40){
        event.preventDefault();
    }
});

document.getElementById("Nombre").addEventListener("keydown", teclear);        
document.getElementById("Correo").addEventListener("keydown", teclear);

document.getElementsByName("UsuarioS").addEventListener("keydown", teclear);

document.getElementsByName("Depto").addEventListener("keydown", teclear);

document.getElementsByName("Colonia").addEventListener("keydown", teclear);

document.getElementsByName("Calle").addEventListener("keydown", teclear);

document.getElementsByName("CPostal").addEventListener("keydown", teclear);

document.getElementsByName("Ciudad").addEventListener("keydown", teclear);

document.getElementsByName("Estado").addEventListener("keydown", teclear);

document.getElementsByName("Tel").addEventListener("keydown", teclear);

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

    function soloNumeros(e) 
                    {                                        
                            key = e.keyCode || e.which;
                            tecla = String.fromCharCode(key).toLowerCase();
                            
                            letras = "1234567890";
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
                        
                        letras = " áéíóúabcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTVWXYZÁÉÍÓÚÜ@_-.1234567890";
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


        function comprobarPass(pass){
        var pass = document.getElementById('ContraseniaS').value;           
        var patron = new RegExp("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
           var comprobacion = patron.test(pass);
           if (comprobacion != false) 
           {
                document.getElementById('validacion3').innerHTML = ' Correcto';
                document.getElementById('validacion3').hidden;               
                document.getElementById('validacion3').style.color = 'green';
                document.getElementById("enviar").style.visibility = 'visible';
           }
           else
           {
               
               document.getElementById('validacion3').innerHTML = 'Mínimo 8 caracteres, que tenga al menos una letra en mayúscula y minúscula y que tenga al menos un carácter especial (@@, %, $, #, &)'; 
                document.getElementById('validacion3').style.color = 'red';
                document.getElementById("enviar").style.visibility = 'hidden';
           }; 
           return comprobacion;
       };


