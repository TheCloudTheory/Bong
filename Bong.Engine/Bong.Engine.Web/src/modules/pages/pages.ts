import * as Bong from '../../modules/bong';

export = Pages;

namespace Pages {
    export type Entity = Bong.EntityModule & {
        title: string,
        url: string,
        body: string
    }
}