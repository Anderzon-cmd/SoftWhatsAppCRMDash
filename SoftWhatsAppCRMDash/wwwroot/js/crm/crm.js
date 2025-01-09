async function getStaticsTime(numberClient) {
    let resultTimeResponse='0';
    let resultTimeClient='0';
    try {
        const response = await fetch(`${apiBaseUrlDash}/chats/time-client?from=${numberClient}`);
        const result= await response.json();
        if (result.error != 0) {
            throw new Error('Service error');
        }

        if (result.data[0].quantityResponse!=0) {
            resultTimeResponse=(result.data[0].time / result.data[0].quantityResponse).toFixed(2)
        }
        if (result.data[1].quantityResponse != 0) {
            resultTimeClient = (result.data[1].time / result.data[1].quantityResponse).toFixed(2)
        }

        return { error: 0, message: 'Success', data: [`${resultTimeResponse} (s/m)`, `${resultTimeClient} (s/m)`] }

    } catch (error) {
        console.error('Error al realizar la peticion de estadisticas de tiempo');
        return { error: 1, message: error.message, data: [resultTimeResponse + ' (s/m)', resultTimeClient + ' (s/m)'] }  
    };
}


async function getChatMessage(numberClient) {
    let message= '';
    try {
        const response = await fetch(`${apiBaseUrlDash}/chats/chat-text-client?from=${numberClient}`);
        const result = await response.json();
        if (result.error != 0) {
            throw new Error('Service error');
        }
        return { error: 0, message: 'Success', data: result.data }
    } catch (error) {
        console.error('Error al realizar la peticion de para obtener los mensajes');
        return { error: 1, message: error.message, data: message }
    };
}

async function getAnalitycChat({ message}) {
    try {
        const response = await fetch(`${apiBaseAnaliticsUrl}/chat-message?`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ text: message })
        });
        
        const result = await response.json();
        if (result.status_code != 200) {
           throw new Error('Peticion no adecuada');
        }
        if (result.detail.error != 0) {
            throw new Error('Service error');
        }
        return { error: 0, message: 'Success', data: result.detail.data }
    } catch (error) {
        console.error('Error al obtener los datos para las estadisticas de datos');
        return { error: 1, message: error.message, data: null }
    }
}

