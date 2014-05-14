using System;
using System.Reflection;
using Tridion.ContentManager;
using Tridion.ContentManager.CommunicationManagement;
using Tridion.ContentManager.Publishing;
using Tridion.ContentManager.Publishing.Rendering;
using Tridion.ContentManager.Publishing.Resolving;
using Tridion.ContentManager.Templating;

namespace Hinttech.Tridion.DevSummit.Unittesting.TestHarness
{
    /// <summary>
    /// TemplatingRenderer for unittesting; this serves as the Engine for render operations
    /// </summary>
    public class UnittestingTemplatingRenderer : TemplatingRenderer, IDisposable
    {
        #region Disposable pattern
        private bool disposed = false; // to detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // dispose-only, i.e. non-finalizable logic
                    if (_session != null) { _session.Dispose(); }
                }

                // shared cleanup logic
                disposed = true;
            }
        }

        ~UnittestingTemplatingRenderer()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Public API
        /// <summary>
        /// Creates a renderer from the given item URIs for the source item and template.
        /// templateUri must be the TCMURI of a compatible template
        /// </summary>
        /// <param name="itemUri">TCMURI of component or page to use for RenderedItem</param>
        /// <param name="templateUri">TCMURI of component template or page template to use for RenderedItem</param>
        public UnittestingTemplatingRenderer(string itemUri, string templateUri)
            : this()
        {
            SetRenderedItem(
                CreateRenderedItem(
                    CreateResolvedItem(
                        this._session.GetObject(itemUri), 
                        this._session.GetObject(templateUri) as Template
                    )
                )
            );
        }
        #endregion

        #region Private implementation
        /// <summary>
        /// Default constructor; initializes TOM.Net session
        /// </summary>
        private UnittestingTemplatingRenderer()
            : base()
        {
            //Setup TOM.Net session
            this._session = new Session();
        }

        /// <summary>
        /// Sets the rendered item as the internal _renderedItem variable of the Engine
        /// </summary>
        /// <param name="renderedItem">The RenderedItem to configure the engine with</param>
        private void SetRenderedItem(RenderedItem renderedItem)
        {
            typeof(TemplatingRenderer).GetField("_renderedItem", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this, renderedItem);
        }

        /// <summary>
        /// Creates a RenderedItem object based on the given ResolvedItem and a default render instruction
        /// </summary>
        /// <param name="resolvedItem">ResolvedItem to render</param>
        /// <returns>RenderedItem</returns>
        private RenderedItem CreateRenderedItem(ResolvedItem resolvedItem)
        {
            return new RenderedItem(
                resolvedItem,
                new RenderInstruction(this._session)
            );
        }

        /// <summary>
        /// Creates a resolved item from the given item and template
        /// </summary>
        /// <param name="item">Identifiable object to act as the source item for rendering</param>
        /// <param name="template">Template to render with</param>
        /// <returns>ResolvedItem</returns>
        private ResolvedItem CreateResolvedItem(IdentifiableObject item, Template template)
        {
            return new ResolvedItem(item, template);
        }
        #endregion
    }
}
