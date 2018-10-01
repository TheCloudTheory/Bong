import * as axios from 'axios';

export default class Repository<TEntity> {
    public list(module: string) : axios.AxiosPromise<Array<TEntity>> {
        return axios.default.get<Array<TEntity>>(module);
    }

    public create<TModel>(module: string, model: TModel) : axios.AxiosPromise<TModel> {
        return axios.default.post(module, model);
    }

    public get<TModel>(module: string, id: string): axios.AxiosPromise<TModel> {
        return axios.default.get(`${module}/${id}`);
    }

    public fetch<TModel>(module: string): axios.AxiosPromise<TModel> {
        return axios.default.get(`${module}`);
    }

    public delete(module: string, id: string): axios.AxiosPromise {
        return axios.default.delete(`${module}/${id}`);
    }

    public update<TModel>(module: string, id: string, data: TModel): axios.AxiosPromise {
        return axios.default.put(`${module}/${id}`, data);
    }
}