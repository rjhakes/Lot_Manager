import { observer } from 'mobx-react-lite';
import React, { useEffect, useRef, useState } from 'react';
import { Grid, List } from 'semantic-ui-react';
import LoadingComponent from '../../../app/layout/LoadingComponent';
import { useStore } from '../../../app/stores/store';
import { Lot } from '../../../app/models/Lot';


export default observer( function LotDashboard() {
    const {lotStore} = useStore();
    const {editMode, openForm, deleteAllLots, loading} = lotStore;

    useEffect(() => {
        lotStore.loadLots();
    }, [lotStore])

    if (lotStore.loadingInitial) return <LoadingComponent content='Loading app' />

    return (
        <>
            <Grid>
                <Grid.Column width='10'>
                    <List>
                        {}
                    </List>
                </Grid.Column>
            </Grid>
        </>
    );
})