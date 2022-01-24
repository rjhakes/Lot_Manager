import { observer } from 'mobx-react-lite';
import React, { useEffect, useRef, useState } from 'react';
import { Grid, List } from 'semantic-ui-react';
import LoadingComponent from '../../../app/layout/LoadingComponent';
import { useStore } from '../../../app/stores/store';
import { Lot } from '../../../app/models/Lot';

export default observer( function LotDetails() {
    return (
        <>
        {/* 
        <Card fluid>
            { <Image src={`/aassets/categoryImages/${buyer.logoFile}`} />}
            <Card.Content>
            <Card.Header>{buyer.bidderNumber}</Card.Header>
            <Card.Meta>
                <span>{buyer.name}</span>
            </Card.Meta>
            <Card.Description>
                {buyer.contactName}: {buyer.phone}, {buyer.email}
            </Card.Description>
            </Card.Content>
            <Card.Content extra>
                <Button.Group widths='3'>
                    <Button onClick={() => openForm(buyer.id)} basic color='green' content='Edit'/>
                    { <Button onClick={() => deleteBuyer(buyer.id)} basic color='red' content='Delete'/> }
                    <Button onClick={cancelSelectBuyer} basic color='grey' content='Close'/>
                </Button.Group>
            </Card.Content>
        </Card>
        */}
        </>
    )
})