/*global
    piranha
*/

piranha.apply = new Vue({
    el: "#apply",
    data: {
        loading: true,
        siteId: null,
        siteTitle: null,
        sites: [],
        items: [],
        model: {
            id: null,
            applyName: null,
            applyEmail: null,
            applyMobile: null,
            applyJob: null,
            applyCV: null,
            applyIntro: null
        }
    },
    methods: {
        load: function (siteId) {
            var self = this;

            if (!siteId) {
                siteId = "";
            }

            fetch(piranha.baseUrl + "manager/api/apply/list/" + siteId)
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