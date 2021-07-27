import { fetchMercaderia, getMercaderiaByTipo, postPedido } from './config.js';

const cards = document.getElementById('cards');
const items = document.getElementById('items');
const footer = document.getElementById('footer');
const btnVerMas = document.querySelectorAll('.ver-mas');
const templateCard = document.getElementById('template-card').content ;
const templateFooter = document.getElementById('template-footer').content;
const templatePedido = document.getElementById('template-pedido').content;
const selectEntrega = document.getElementById('seleccione-entrega');
const fragment = document.createDocumentFragment();

let pedido = {}
let mercaderias = []

document.addEventListener('DOMContentLoaded', () => {
    renderMercaderia();
});

cards.addEventListener('click', e => {
    addPedido(e);
});

items.addEventListener('click', e => {
    btnAccion(e);
});


const renderMercaderia = async () => {
    var mercaderiaFetch = await fetchMercaderia();
    pintarcards(mercaderiaFetch);
}

const enviarPedido = async () => {
    var formaEntrega = document.getElementById('entrega').value;
    console.log(formaEntrega)
    var datos = {"mercaderias": mercaderias,
                "formaEntrega":  formaEntrega };
    console.log(datos);

    let res = await postPedido(datos);

    if (res.status === 201) {
        const data = await res.json()
        console.log(data);
        respuesta.innerHTML = `   
        <div class="card text-center p-0 my-2" id="rta">
            <div class="card-header bg-transparent text-success border-0">
                <i class="far fa-check-circle display-4 d-block"></i>
                <h5 class="card-title text-success display-6 d-block">Registro exitoso</h5>
            </div>
            <div class="card-body">
                <svg xmlns="http://www.w3.org/2000/svg" style="display: none;">
                    <symbol id="check-circle-fill" fill="currentColor" viewBox="0 0 16 16">
                        <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zm-3.97-3.03a.75.75 0 0 0-1.08.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-.01-1.05z"/>
                    </symbol>  
                </svg>
                <div class="alert alert-success d-flex align-items-center" role="alert">
                    <svg class="bi flex-shrink-0 me-2" width="24" height="24" role="img" aria-label="Success:"><use xlink:href="#check-circle-fill"/></svg>
                    <div>
                        El Pedido se ha registrado con éxito.
                    </div>
                </div>
                <a href="index.html" class="btn btn-primary">Ir al menu </a>
                <button onclick="resetRespuesta()" class="btn btn-primary">Seguir ordenando </button>
            </div>
        </div> `;
    }
    if (res.status === 400) {
        const data = await res.json()
        console.log(data);
        respuesta.innerHTML = ` 
        <div class="card text-center p-0 my-2" id="rta">
            <div class="card-header bg-transparent text-danger border-0">
                <i class="fas fa-exclamation-triangle display-4 d-block"></i>
                <h5 class="card-title text-danger display-6 d-block">Registro Fallido</h5>
            </div>
            <div class="card-body">               
                <svg xmlns="http://www.w3.org/2000/svg" style="display: none;"> 
                    <symbol id="exclamation-triangle-fill" fill="currentColor" viewBox="0 0 16 16">
                        <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
                    </symbol>
                </svg>          
                <div class="alert alert-danger d-flex align-items-center" role="alert">
                    <svg class="bi flex-shrink-0 me-2" width="24" height="24" role="img" aria-label="Danger:"><use xlink:href="#exclamation-triangle-fill"/></svg>
                    <div>
                        El Pedido no se ha registrado.
                    </div>
                </div>
                <a href="index.html" class="btn btn-danger">Ir al menu </a>
                <a onclick="resetRespuesta()" class="btn btn-danger">Hacer otro Pedido </a>
            </div>
        </div>  `;
    }
}


// Pintar mercaderia
const pintarcards = data => {
    cards.innerHTML = '';
    data.forEach(mercaderia => {
        templateCard.querySelector('#nombre').textContent = mercaderia.nombre;
        templateCard.querySelector('span').textContent = mercaderia.precio;
        templateCard.querySelector('img').setAttribute("src", mercaderia.imagen);
        templateCard.querySelector('img').setAttribute("alt", mercaderia.nombre);
        templateCard.querySelector('#btn-agregar').dataset.id = mercaderia.mercaderiaId;
        
        templateCard.querySelector('.modal').setAttribute('id', 'modal-'+mercaderia.mercaderiaId);
        templateCard.querySelector('#detalle-nombre').textContent = mercaderia.nombre;
        templateCard.querySelector('#detalle-precio').textContent = mercaderia.precio;
        templateCard.querySelector('#tipo').textContent = mercaderia.tipo;
        templateCard.querySelector('#ingredientes').textContent = mercaderia.ingredientes;
        templateCard.querySelector('#preparacion').textContent = mercaderia.preparacion;

        //Agrego los atributos para manejar el modal de bootstrap
        templateCard.querySelector('#btn-agregar').setAttribute('data-bs-toggle', 'modal');
        templateCard.querySelector('#btn-agregar').setAttribute('data-bs-target', '#staticBackdrop')
        //Agrego los atributos de bootstrap para el modal de detalle de mercaderia
        templateCard.querySelector('#btn-detalles').setAttribute('data-bs-toggle', 'modal');
        templateCard.querySelector('#btn-detalles').setAttribute('data-bs-target', '#modal-'+mercaderia.mercaderiaId);
        const clone = templateCard.cloneNode(true)
        fragment.appendChild(clone)
    });
    cards.appendChild(fragment) 
}

const addPedido = e => {
    if(e.target.classList.contains('btn-outline-success')) {
        setPedido(e.target.parentElement);
    }
    e.stopPropagation();
}

const setPedido = objeto => {
    const mercaderia = {
        id: objeto.querySelector('#btn-agregar').dataset.id,
        nombre: objeto.querySelector('#nombre').textContent,
        precio: objeto.querySelector('span').textContent,
        //tipo: objeto.querySelector('#tipo').textContent,
        cantidad: 1
    }
    // Accedo al elemento que se esta repitiendo
    if(pedido.hasOwnProperty(mercaderia.id)){
        mercaderia.cantidad = pedido[mercaderia.id].cantidad + 1;
    }

    pedido[mercaderia.id] = {...mercaderia}
    mercaderias.push(mercaderia.id);
    console.log(mercaderias)
    pintarPedido();
}

const pintarPedido = () => {
    items.innerHTML = '';
    Object.values(pedido).forEach(mercaderia => {
        templatePedido.querySelectorAll('td')[0].textContent = mercaderia.nombre;
        templatePedido.querySelectorAll('td')[1].textContent = mercaderia.cantidad;
        templatePedido.querySelector('#precioTotal').textContent = mercaderia.cantidad * mercaderia.precio;

        // Botones
        templatePedido.querySelector('.btn-info').dataset.id = mercaderia.id;
        templatePedido.querySelector('.btn-danger').dataset.id = mercaderia.id;

        const clone = templatePedido.cloneNode(true);
        fragment.appendChild(clone);
    });
    items.appendChild(fragment);
    selectEntrega.innerHTML =  ` <div class="form-floating">
    <form name="formEntrega">
        <select class="form-select" id="entrega" name="selectEntrega" aria-label="Floating label select example">
        <option value="" disabled selected>Elija una opcion</option>  
        <option value="1">Salon</option>
        <option value="2">Delivery</option>
        <option value="3">Pedidos Ya</option>
        </select>
        <label for="entrega">Forma de entrega</label>
    </form>
    <button type="button" class="btn btn-success" id="enviar-pedido">Confirmar</button>    
</div> `;
    pintarFooter();
}

const pintarFooter = () => {
    footer.innerHTML = '';
    if(Object.keys(pedido).length===0){
        footer.innerHTML = '<th scope="row" colspan="5">Pedido vacío - comience a ordenar!</th>';
        selectEntrega.innerHTML = '';
        return 
    }

    const nCantidad = Object.values(pedido).reduce((acc, {cantidad}) => acc +cantidad, 0);
    const nPrecio = Object.values(pedido).reduce((acc, {cantidad, precio}) => acc + cantidad * precio, 0);
    
    templateFooter.querySelectorAll('td')[0].textContent = nCantidad;
    templateFooter.querySelector('span').textContent = nPrecio;

    const clone = templateFooter.cloneNode(true);
    fragment.appendChild(clone);
    footer.appendChild(fragment);

    const btnVaciar = document.getElementById('vaciar-pedido');
    btnVaciar.addEventListener('click', () => {
        pedido = {}
        mercaderias = []
        console.log(mercaderias)
        pintarPedido();
    });  

    const btnPedido = document.getElementById('enviar-pedido');
    btnPedido.addEventListener('click', () => {
        enviarPedido();
    });
}

const btnAccion = e => {

   // Accion de aumentar
    if(e.target.classList.contains('btn-info')) {
        const mercaderia = pedido[e.target.dataset.id];
        mercaderia.cantidad ++ ;       
        pedido[e.target.dataset.id] = { ...mercaderia}
        mercaderias.push(mercaderia.id);
        pintarPedido();
    
    }
   // Accion de disminuir 
    if(e.target.classList.contains('btn-danger')) {
        const mercaderia = pedido[e.target.dataset.id];
        mercaderia.cantidad -- ; 
        if(mercaderia.cantidad === 0){
            delete pedido[e.target.dataset.id];
        }
        //Saco la mercaderia del array para el post de pedido
        //Si esta repetida en el array, saco la ultima
        const indice = mercaderias.lastIndexOf(mercaderia.id);
        if(indice !== -1){
            mercaderias.splice(indice, 1);
        }
        pintarPedido();
    }

    e.stopPropagation();
}

btnVerMas.forEach(btn => {
    btn.addEventListener('click', async () => {
        let id = btn.id;
        let mercaderiasByTipo = await getMercaderiaByTipo(id);
        pintarcards (mercaderiasByTipo); 
    });
});
