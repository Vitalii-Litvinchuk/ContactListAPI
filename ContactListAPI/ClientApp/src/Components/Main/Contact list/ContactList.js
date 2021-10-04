import { useEffect } from "react";
import { connect } from "react-redux";

// Import components
import ContactItem from "./Contact item/ContactItem";

// Import actions
import { ChangeFetch, getAllList } from "../../../Actions/ListActions";

// Import Services
import APIService from "../../../Services/APIService";

const ContactList = ({ ContactList, IsRequest, SearchList, isSearch, isFetch,
    getAllList, ChangeFetch }) => {

    useEffect(() => {
        if (!isFetch) {
            let api = new APIService();
            api.fetchContactList().then(data => {
                var list = data.List;
                var tempList = [];

                list.forEach(element => {
                    tempList.push({
                        Name: element.name,
                        Id: element.id,
                        Phone: element.phone,
                        Email: element.email,
                        Status: element.status,
                        Gender: element.gender,
                        Image: element.image
                    })
                });

                getAllList(tempList);
            });
            ChangeFetch(true);
        }
    }, []); // [ContactList]); - trouble with Change/Get status

    let item;
    if (isSearch)
        item = SearchList.map(listItem => {
            return (
                <ContactItem key={listItem.Id}
                    {...listItem}
                />
            )
        });
    else
        item = ContactList.map(listItem => {
            return (
                <ContactItem key={listItem.Id}
                    {...listItem}
                />
            )
        });

    if (IsRequest && ContactList.length === 0)
        return (
            <section>
                <div className="lds-roller"><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div></div>
            </section>
        )
    return (
        <section>
            {item.length > 0 ? item : <p className="emptyList">Contact list is empty.</p>}
        </section>

    )

}

const mapStateToProps = ({ ListReducer }) => {
    const { ContactList, IsRequest, SearchList, isSearch, isFetch } = ListReducer;
    return { ContactList, IsRequest, SearchList, isSearch,isFetch };
}

const mapDispatchToProps = {
    getAllList, ChangeFetch
}

export default connect(mapStateToProps, mapDispatchToProps)(ContactList);