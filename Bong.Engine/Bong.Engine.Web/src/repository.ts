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
}