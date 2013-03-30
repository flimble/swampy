describe('test with jasmine-jquery', function () {
    it('should load many fixtures into DOM', function () {
        loadFixtures('JavaScript1spec.html');
        expect($('#jasmine-fixtures')).toSomething();
    });

});
