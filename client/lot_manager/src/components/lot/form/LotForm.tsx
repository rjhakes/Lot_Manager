import { observer } from 'mobx-react-lite';
import React, { ChangeEvent, useEffect, useRef, useState } from 'react';
import { Button, Form, Input, Segment } from 'semantic-ui-react'
import LoadingComponent from '../../../app/layout/LoadingComponent';
import { useStore } from '../../../app/stores/store';
import { Lot } from '../../../app/models/Lot';

export default observer( function LotForm() {
    const {lotStore} = useStore();
    const {selectedLot, closeForm, createLot, updateLot, loading} = lotStore;

    const initialState = selectedLot ?? {
        id: '',
        lotName: '',
        phone: '',
        addrLine1: '',
        addrLine2: '',
        city: '',
        state: '',
        zip: '',
        spots: []
    }
    const [lot, setLot] = useState(initialState);


    function handleSubmit() {
        lot.id ? updateLot(lot) : createLot(lot);
    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const {name, value} = event.target;
        setLot({...lot, [name]: value});
    }

    return (
        <Segment className='add-form create-form' clearing>
            <Form onSubmit={handleSubmit} autoComplete='off'>
                <Form.Input required={true} label='Lot Name' placeholder='Lot Name' value={lot.lotName} name='lotName' onChange={handleInputChange}/>
                <Form.Input required={true} type='phone' label='Phone #' placeholder='Phone #' value={lot.phone} name='phone' onChange={handleInputChange}/>
                <Form.Input required={true} label='Address Line 1' placeholder='Address Line 1'value={lot.addrLine1} name='addrLine1' onChange={handleInputChange}/>
                <Form.Input required={true} label='Address Line 2' placeholder='Address Line 2'value={lot.addrLine2} name='addrLine2' onChange={handleInputChange}/>
                <Form.Input required={true} label ='City' placeholder='City' value={lot.city} name='city' onChange={handleInputChange}/>
                <Form.Input required={true} label ='State' placeholder='State' value={lot.state} name='state' onChange={handleInputChange}/>
                <Form.Input required={true} label ='Zip' placeholder='Zip' value={lot.zip} name='zip' onChange={handleInputChange}/>
                <Button onClick={handleSubmit} loading={loading} floated='right' positive type='submit' content='Submit' />
                <Button onClick={closeForm} floated='right' type='button' content='Cancel' />
            </Form>
        </Segment>
    )
})