import * as React from 'react';
import * as Bong from '../bong';
import * as Authentication from './authentication';

import Repository from '../../repository';
import { AxiosPromise } from 'axios';
import RadioButtonGroup from '../../ui/radioButtonGroup';

export default class AuthenticationEdit extends Bong.EditFormModule<Authentication.Entity, AuthenticationEditState> {
    private repository: Repository<Authentication.Entity>;

    protected Module: string;
    protected Title: string;

    constructor(props: any) {
        super(props);

        this.Module = Authentication.Module;
        this.Title = 'Authentication';
        this.state = { id: null };

        this.repository = new Repository<Authentication.Entity>();
    }

    protected fetchData(): AxiosPromise<Authentication.Entity> {
        return this.repository.fetch(Authentication.Module);
    }

    protected setValues(model: Authentication.Entity): void {
        this.setState({
            id: model.id
        })
    }

    protected getForm(): JSX.Element {
        return (
            <div>
                <RadioButtonGroup 
                    label="Authentication Type" 
                    fields={["Basic"]} 
                    name="authenticationType" 
                    values={[Authentication.AuthenticationType.Basic as number]} 
                    defaultValue={Authentication.AuthenticationType.Basic}
                />
            </div>
        ); 
    }
}

type AuthenticationEditState = {
    id: string
}