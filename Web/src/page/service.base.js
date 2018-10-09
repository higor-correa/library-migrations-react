import axios, { AxiosPromise } from 'axios'

class ServiceBase extends Object {

    constructor() {
        super();
        this.url = "https://localhost:5001/api/";        
    }

    get(uri){
        let finalUri = this.url + uri;

        return axios.get(finalUri);
    }

}
export default ServiceBase;