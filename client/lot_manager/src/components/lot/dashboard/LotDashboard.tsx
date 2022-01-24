import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { Grid } from 'semantic-ui-react';
import LoadingComponent from '../../../app/layout/LoadingComponent';
import { useStore } from '../../../app/stores/store';
// import { Lot } from '../../../app/models/Lot';
import LotList from './LotList';
// import LotDetails from '../details/LotDetails';


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
                    <LotList />
                </Grid.Column>
                {/* <Grid.Column width='6'>
                    <LotDetails />
                </Grid.Column> */}
            </Grid>
        </>
    );
})