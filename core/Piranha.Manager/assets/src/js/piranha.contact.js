/*global
    piranha
*/

 piranha.contact = new Vue({
    el: "#contact",
    data: {
        loading: true,
        siteId: null,
        siteTitle: null,
        sites: [],
        items: [],
        model: {
            id: null,
            contactName: null,
            contactEmail: null,
            contactTitle: null,
            contactContent: null
        }
    },
    methods: {
        load: function (siteId) {
            var self = this;

            if (!siteId) {
                siteId = "";
            }

            fetch(piranha.baseUrl + "manager/api/contact/list/" + siteId)
                .then(function (response) {
                    console.log('response', response);
                     return response.json();
                })
                .then(function (result) {
                    console.log(result);

                    self.siteId = result.siteId;
                    self.siteTitle = result.siteTitle;
                    self.sites = result.sites;
                    self.items = result.items;
                })
                .catch(function (error) { console.log("error:", error ); });
        }
    },
    updated: function () {
        this.loading = false;
    }
});