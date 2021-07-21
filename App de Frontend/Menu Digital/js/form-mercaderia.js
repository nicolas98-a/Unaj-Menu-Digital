import {postMercaderia} from './config.js'; 

(function () {
    'use strict';

    //var form = document.getElementById('formulario-mercaderia');
    var form = document.querySelector('.needs-validation');
    
    form.addEventListener(
        'submit',
        function (event) {
        if (!form.checkValidity()) {
            console.log(form.checkValidity())
            event.preventDefault();
            event.stopPropagation();
        } else {
            event.preventDefault();
            enviarFormulario(form);
        }

        form.classList.add('was-validated');
        },
            false
    );
    })();
  // Fin de validacion de formulario con Bootstrap

    const  enviarFormulario = async (formulario) => {
        let nombre = formulario.elements.nombre.value;
        let tipo = formulario.elements.tipoMercaderiaId.value;
        let precio = formulario.elements.precio.value;
        let ingredientes = formulario.elements.ingredientes.value;
        let preparacion = formulario.elements.preparacion.value;
        let imagen = formulario.elements.imagen.value;

        let datos = {
            nombre: nombre,
            tipoMercaderiaId: tipo,
            precio: precio,
            ingredientes: ingredientes,
            preparacion: preparacion,
            imagen: imagen
        }
        let datosJson = JSON.stringify(datos);
        console.log(datosJson);

        let response = await postMercaderia(datosJson);

        if (response.status === 201){
            formulario.innerHTML = `   
        <div class="card text-center p-0 my-2 ">
            <div class="card-header bg-transparent text-success border-0">
                <i class="far fa-check-circle display-4 d-block"></i>
                <h5 class="card-title text-success display-4 d-block">Registro exitoso</h5>
            </div>
            <div class="card-body">
                <p class="card-text lead">La Mercaderia se ha registrado con éxito.</p>
                <a href="index.html" class="btn btn-primary m-auto">Ir al menu </a>
                <a href="form-mercaderia.html" class="btn btn-primary m-auto">Cargar otra Mercaderia </a>
            </div>
        </div> `;
        }
        if (response.status === 400){
            formulario.innerHTML = ` 
        <div class="card text-center p-0 my-2 ">
            <div class="card-header bg-transparent text-danger border-0">
                <i class="fas fa-exclamation-triangle"></i>
                <h5 class="card-title text-danger display-4 d-block">Registro Fallido</h5>
            </div>
            <div class="card-body">
                <p class="card-text lead">La Mercaderia no se ha registrado.</p>
                <a href="index.html" class="btn btn-danger m-auto">Ir al menu </a>
                <a href="form-mercaderia.html" class="btn btn-danger m-auto">Cargar otra Mercaderia</a>
            </div>
        </div>  `;
        }
    }


