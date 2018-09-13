import * as axios from 'axios';

export default class Repository<TEntity> {
    public list(module: string) : axios.AxiosPromise<Array<TEntity>> {
        return axios.default.get<Array<TEntity>>(module);
    }
}