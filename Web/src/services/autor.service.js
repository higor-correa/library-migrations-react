import ServiceBase from "./service.base";

class AutorService extends ServiceBase {

    getAutores = function (callbackSucesso, callBackFalha) {
        this.get("Author", callbackSucesso, callBackFalha);
    };
}

export default AutorService;