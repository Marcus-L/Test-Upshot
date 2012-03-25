Upshot Test App
===============

A few tests demonstrating upshot bugs and features

Features
--------

### OData Provider

There weren't really any examples of this so I looked through the source and came up with an example that's equivalent to the WebAPI version in this test app. Note that there's a comment in the code: "Saving edits through the OData data provider is not supported." so don't expect to be able to save yet.

Bugs
----

### Calling refresh() on an upshot datasource doesn't update collection properties correctly.

When a different set of results is returned in the collection property, those are merged into the existing set of entities instead of replacing them. This is the "AddRemoveThings" button in the test project, it calls a method to do some adds/deletes, then re-calls refresh() which returns the correct results, but the upshot collection entities get merged instead of replaced (i.e. the new item shows up but the deleted item doesn't get removed).

### Calling reset() on a datasource doesn't actually reset the child collection entities!

They are still stored by upshot and will be re-merged if you try to call refresh() again. This is the "TryResetRefresh" button in the test project (click this after AddRemoveThings)

### Inserting a parent+child in a single commitChanges() doesn't work.

This is an extremely basic task scenario that seems cause a NYI error. This is the "TryInsertParentAndChild" button in the test project.