import axios from 'axios'

class ServiceBase {
    url = "";
    
    constructor(url) {
        this.url = url || "https://localhost:5001/api/";
    }

    get(uri, callbackSucesso, callbackFalha) {
        uri = verificarBarras(uri);

        let finalUri = this.url + uri;

        axios.get(finalUri).then(result => {
            if (callbackSucesso)
                callbackSucesso(result.data);
        }).catch(result => {
            if (callbackFalha && result.response)
                callbackFalha(result.response);
            else if (result.request)
                callbackFalha({ status: 404 });
        });
    }
}
export default ServiceBase;

function verificarBarras(uri) {
    if (uri[0] === "/")
        uri = uri.substr(1, uri.length - 1);

    if (uri[uri.length - 1] === "/")
        uri = uri.substr(0, uri.length - 1);

    return uri;
}