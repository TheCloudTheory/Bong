import * as React from 'react';

export = Bong;

namespace Bong {
    export class Module extends React.Component {}

    export abstract class FormModule extends React.Component {
        protected abstract getForm() : JSX.Element;
    }

    export class EntityModule {
        
    }
}