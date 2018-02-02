var Marionette = require('marionette');
var SearchResultCollectionView = require('./SearchResultCollectionView');
var Backbone = require('backbone');

module.exports = Marionette.CompositeView.extend({
    template : 'AddMovies/MultiSearchResultViewTemplate',

    regions : {
        moviesResult : '#movies-result',
    },

    initialize : function(options, collection) {
        this.options = options;
        this.isExisting = options.existing || false;
        this.isMulti = options.multi || true;
        this.collection = collection;
    },

    templateHelpers : function() {
        return this.options;
    },

    onRender : function() {
        if (this.collection.model != undefined) {
            this.moviesResultCollection = new Backbone.Collection(this.collection.model.get("movies"));
            this.resultCollectionView = new SearchResultCollectionView({
                collection : this.moviesResultCollection,
                isExisting : this.isExisting
            });
            this.moviesResult.show(this.resultCollectionView);
        }

    }
});
