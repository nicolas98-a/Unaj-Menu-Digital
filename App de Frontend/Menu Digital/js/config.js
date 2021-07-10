const BASE_URL = "https://localhost:44368/api/";

const handleError = (err) => {
    console.warn(err);
    return new Response(JSON.stringify(
        {
            status: 400,
            message: err
        }
    ));
};

export const fetchMercaderia = async () => {
    
        const res = await fetch(BASE_URL + 'Mercaderia').catch(handleError);
        const data = await res.json();
        
        return data;
}

export const getMercaderiaByTipo = async (id) => { 
        const response = await fetch(BASE_URL + 'Mercaderia'+'?tipo='+id).catch(handleError);
        const data = await response.json();

        return data;
}

export const postPedido = async (datos) => {
    const settings = {
        method: 'POST',
        body: JSON.stringify(datos), 
        headers:{
        'Content-Type': 'application/json'
        }
    }
    
    let response = await fetch(BASE_URL + 'Comanda', settings).catch(handleError);

    return response; 
}

export const fetchPedidos = async (fecha) => {
    
        const res = await fetch(BASE_URL + 'Comanda' + '?fecha=' + fecha)
        const data = await res.json()

        return data;
}

export const postMercaderia = async (datos) => {
    const settings = {
        method: 'POST',
        body: datos,
        headers:{
            'Content-Type': 'application/json;charset=UTF-8'
            } 
    }
    let response = await fetch(BASE_URL + 'Mercaderia', settings).catch(handleError);

    return response; 
}