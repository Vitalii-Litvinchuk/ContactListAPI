
export default class APIService {

    URL = "https://localhost:5001/";

    ContactURLS = {
        GetList: "get-all-contacts",
        AddContact: "add-new-contact",
        UpdateList: "update-contacts",
        UpdateContact: "update-contact",
        DeleteContact: "delete-contact"
    }

    async fetchContactList() {
        const List = await fetch(this.URL += this.ContactURLS.GetList)
            .then(responce => {
                return responce.json();
            }).then(data => {
                if (data == null) {
                    return {
                        List: []
                    }

                } else {
                    return {
                        List: data
                    }
                }
            })
            .catch(err => console.log(err))
        return List;
    }

    // updateDatabse = (List) => {
    //     fetch(this.URL + this.ContactURLS.UpdateList,
    //         {
    //             headers: {
    //                 'Content-Type': 'application/json'
    //             },
    //             method: "PUT",
    //             body: JSON.stringify(List)
    //         })
    //         .then(res => console.log(res))
    //         .catch(res => console.log(res))
    //     return this;
    // }

    updateContact = (contact) => {
        fetch(this.URL + this.ContactURLS.UpdateContact,
            {
                headers: {
                    'Content-Type': 'application/json'
                },
                method: "PUT",
                body: JSON.stringify(contact)
            })
            .then(res => console.log(res))
            .catch(res => console.log(res))
    }

    addToDatabase = (contact) => {
        fetch(this.URL + this.ContactURLS.AddContact,
            {
                headers: {
                    'Content-Type': 'application/json'
                },
                method: "POST",
                body: JSON.stringify(contact)
            })
            .then(res => console.log(res))
            .catch(res => { console.log(res); })
    }

    deleteContact = (Id) => {
        fetch(this.URL + this.ContactURLS.DeleteContact,
            {
                headers: {
                    'Content-Type': 'application/json'
                },
                method: "DELETE",
                body: JSON.stringify(Id)
            })
            .then(res => console.log(res))
            .catch(res => console.log(res))
    }

}
