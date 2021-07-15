import { fetchPedidos} from './config.js';

const comandas = document.getElementById('comandas');
const pedidoTableBody = document.getElementById('pedidoTableBody');
//const fragment = document.createDocumentFragment();

const fecha = new Date();
console.log(fecha);
var año = fecha.getFullYear();
console.log(año);
var mes = fecha.getMonth()+1
if (mes < 10) {
    mes = "0" + mes; 
}
console.log(mes)
var dia = fecha.getDate();
console.log(dia);
if (dia < 10) {
    dia = "0" + dia;
}

var f = año.toString() + '-' + mes.toString() + "-" + dia.toString();
console.log(f)

document.addEventListener('DOMContentLoaded', () => {
    renderPedidos();
});

const renderPedidos = async () => {
    let pedidosJson = await fetchPedidos(f);
    if (pedidosJson.length === 0) {
        comandas.innerHTML = ` 
        <div class="container mt-5">
            <div class="alert alert-primary d-flex align-items-center" role="alert">
                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-exclamation-triangle-fill flex-shrink-0 me-2" viewBox="0 0 16 16" role="img" aria-label="Warning:">
                    <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
                </svg>      
                No hay Pedidos para mostrar
            </div>
        </div>
        `;
    }

    pintarComandas(pedidosJson);
}

const pintarComandas = data => {
    data.forEach(pedido => {
        pedidoTableBody.insertAdjacentHTML('beforeend', getPedidoTable(pedido));
        mercaderiaDelPedido(pedido);
    });
}

const getPedidoTable = (pedidoJson) => {
    return (
        `
        <tr>
            <th scope="row">${pedidoJson.comandaId}</th>
            <td style="margin:10%">${pedidoJson.formaEntrega}</td>
            <td>${pedidoJson.precioTotal}</td>
            <td>
                <div class="accordion" id="accordion-${pedidoJson.comandaId}"></div>
            </td>
        </tr>

        `
    );
    
}

const mercaderiaDelPedido = (pedidoJson) => {
    let acordion = document.getElementById(`accordion-${pedidoJson.comandaId}`);
    pedidoJson.mercaderia.forEach(plato => {
        let elemento = document.createElement('div');
        elemento.innerHTML = 
        `
        <div class="accordion-item">
        <h2 class="accordion-header" id="heading-${plato.mercaderiaId}">
          <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapse-${pedidoJson.comandaId}-${plato.mercaderiaId}" aria-expanded="true" aria-controls="collapse-${pedidoJson.comandaId}-${plato.mercaderiaId}">
            ${plato.nombre}
          </button>
        </h2>
        <div id="collapse-${pedidoJson.comandaId}-${plato.mercaderiaId}" class="accordion-collapse collapse show" aria-labelledby="heading-${plato.mercaderiaId}" data-bs-parent="#accordion-${pedidoJson.comandaId}">
          <div class="accordion-body">
          <p>Id: <span>${plato.mercaderiaId}</span></p>
          <p>Tipo: <span>${plato.tipo}</span></p>
          <p>Precio: $ <span>${plato.precio}</span></p>
          <p>Ingredientes <span>${plato.ingredientes}</span></p>
          <p>Preparacion <span>${plato.preparacion}</span></p> 
          </div>
        </div>
      </div>
        `;
        acordion.appendChild(elemento);
    })
    
}
/*
const fetchPedidos = async () => {
    try {
        const res = await fetch('https://localhost:44368/api/Comanda'+ '?fecha='+ f)
        const data = await res.json()
        console.log(data)
        if (data.length === 0) {
            comandas.innerHTML = ` 
            <div class="container mt-5">
                <div class="alert alert-primary d-flex align-items-center" role="alert">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-exclamation-triangle-fill flex-shrink-0 me-2" viewBox="0 0 16 16" role="img" aria-label="Warning:">
                        <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
                    </svg>      
                    No hay Pedidos para mostrar
                </div>
            </div>
            `;
        }
        pintarComandas(data)
    } catch (error) {
        console.log(error)
    }
}

const pintarComandas = data => {
    data.forEach(pedido => {   
        let p = document.createElement('div');
        p.innerHTML =  `<div class="col">
        <div class="card text-dark bg-light mb-3" style="max-width: 18rem;">
            <div class="card-header">Fecha: ${pedido.fecha}</div>
            <div class="card-body">
                <h5 class="card-title">Id : ${pedido.comandaId}</h5>
                <p class="card-text">Precio: $ ${pedido.precioTotal}</p>
                <p class="card-text">Forma de entrega: ${pedido.formaEntrega}</p>
                <h4 class="card-text">Mercaderias: </h4>                       
                <ul class="list-group" id="${pedido.comandaId}"></ul>
            </div>    
        </div>
    </div> `;
    comandas.appendChild(p);
    let lista = document.getElementById(`${pedido.comandaId}`)
    pedido.mercaderia.forEach(mercaderia => {
        let elemento = document.createElement('li');
        elemento.innerHTML = `
        <h5>${mercaderia.nombre}</h5>
        <p>Id: <span>${mercaderia.mercaderiaId}</span></p>
        <p>Tipo: <span>${mercaderia.tipo}</span></p>
        <p>Precio: $ <span>${mercaderia.precio}</span></p>
        <p>Ingredientes <span>${mercaderia.ingredientes}</span></p>
        <p>Preparacion <span>${mercaderia.preparacion}</span></p>  `;
        
        lista.appendChild(elemento);
        
    }); 
        
    });
}
*/
