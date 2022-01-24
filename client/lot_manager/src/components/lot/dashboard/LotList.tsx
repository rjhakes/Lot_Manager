import { observer } from 'mobx-react-lite';
import React, { SyntheticEvent, useState } from 'react';
import { Button, Item, Segment } from 'semantic-ui-react';
import LoadingComponent from '../../../app/layout/LoadingComponent';
import { useStore } from '../../../app/stores/store';
// import { Lot } from '../../../app/models/Lot';

export default observer( function LotList() {
    const {lotStore} = useStore();
    const {lots, deleteLot, loading, openForm} = lotStore;

    const [target, setTarget] = useState('');

    // function handleLotDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
    //     setTarget(e.currentTarget.name);
    //     deleteLot(id);
    // }

    if(lotStore.loadingInitial) return <LoadingComponent content='Loading app' />

    return (
        <>
        <Segment>
            <Item.Group divided>
                {lots.map(lot => (
                    <Item key={lot.id}>
                        <Item.Content>
                            <Item.Header as='a'>{lot.lotName}</Item.Header>
                            <Item.Meta>{lot.phone}</Item.Meta>
                            <Item.Description>
                                <div>{lot.addrLine1}</div>
                                <div>{lot.addrLine2}</div>
                                <div>{lot.city}, {lot.state} {lot.zip}</div>
                            </Item.Description>
                            <Item.Extra>
                                <Button floated='right' content='View' color='blue' />
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
        </>
    )
})