"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const axios = require("axios");
class Repository {
    list(module) {
        return axios.default.get(module);
    }
    create(module, model) {
        return axios.default.post(module, model);
    }
    get(module, id) {
        return axios.default.get(`${module}/${id}`);
    }
    fetch(module) {
        return axios.default.get(`${module}`);
    }
    delete(module, id) {
        return axios.default.delete(`${module}/${id}`);
    }
    update(module, id, data) {
        return axios.default.put(`${module}/${id}`, data);
    }
}
exports.default = Repository;
//# sourceMappingURL=repository.js.map