const router =
<Route history={history}>
  <Route component={App}>
    <Route path='/' component={Home} />
  </Route>
</Route>;

export default router;