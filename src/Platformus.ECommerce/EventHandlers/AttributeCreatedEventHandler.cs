﻿// Copyright © 2018 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Barebone;
using Platformus.ECommerce.Data.Entities;
using Platformus.ECommerce.Events;

namespace Platformus.ECommerce.EventHandlers
{
  public class AttributeCreatedEventHandler : IAttributeCreatedEventHandler
  {
    public int Priority => 1000;

    public void HandleEvent(IRequestHandler requestHandler, Attribute attribute)
    {
      new AttributeSerializationManager(requestHandler).SerializeAttribute(attribute);
      requestHandler.GetService<ICache>().RemoveAll();
    }
  }
}