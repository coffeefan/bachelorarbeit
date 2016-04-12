(function ($) {
  module('jQuery#AuthenticationLightbox', {
    setup: function () {
      this.elems = $('#qunit-fixture').children();
    }
  });

  test('is chainable', function () {
    expect(1);
    strictEqual(this.elems.AuthenticationLightbox(), this.elems, 'should be chainable');
  });

  test('is AuthenticationLightbox', function () {
    expect(1);
    strictEqual(this.elems.AuthenticationLightbox().text(), 'AuthenticationLightbox0AuthenticationLightbox1AuthenticationLightbox2', 'should be AuthenticationLightbox');
  });

}(jQuery));
