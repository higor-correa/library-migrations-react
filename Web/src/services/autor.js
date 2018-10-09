import ServiceBase from "./service.base";

class AutorService extends ServiceBase {
    constructor() {
        super();
    }

    getAutores = function (callback) {
        this.get("Author/")
            .then(result => callback(result.data));
    };
}

export default AutorService;